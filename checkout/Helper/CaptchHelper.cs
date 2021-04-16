using checkout.Entity;
using checkout.Entity.Qo;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace checkout.Helper
{
    class CaptchHelper
    {
        static EdgeDriver getDriver()
        {
            var chromeDriverService = EdgeDriverService.CreateChromiumService(Directory.GetCurrentDirectory());
            chromeDriverService.HideCommandPromptWindow = true;
            var options = new EdgeOptions
            {
                UseChromium = true
            };

            return new EdgeDriver(chromeDriverService, options);
        }

        public static CaptchData getTicket(int count) 
        {
            EdgeDriver driver = getDriver();

            var data = new CaptchData();
            try
            {
                // 跳转到滑块页
                driver.Navigate().GoToUrl("file://" + Directory.GetCurrentDirectory() + "/Res/Tcaptch.html");
                // 隐式等待10s
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                // 切换到滑块对应的iframe
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver.SwitchTo().Frame(driver.FindElementById("tcaptcha_iframe"));

                // 等待ticket成功出现
                Thread.Sleep(500);
                new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until((d) =>
                {
                    try
                    {
                        return d.FindElement(By.Id("slideBg")).GetProperty("src");
                    }
                    catch (Exception) { return null; }
                });


                // 执行js代码
                js.ExecuteScript(File.ReadAllText(Directory.GetCurrentDirectory() + "/Res/slide.js"));


                // 等待ticket成功出现
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until((d) =>
                {
                    try
                    {
                        driver.SwitchTo().ParentFrame();
                        return d.FindElement(By.Id("ticket")).GetProperty("text");
                    }
                    catch (Exception) { return null; }
                });


                // 再切回父iframe
                driver.SwitchTo().ParentFrame();

                data.ticket = driver.FindElementById("ticket").GetProperty("text");
                data.randstr = driver.FindElementById("randstr").GetProperty("text");
            }
            catch (Exception)
            {
                if (driver.ToString().Contains("null"))
                {
                    return null;
                }
                driver.Quit();

                if (count++ > 5)
                {
                    return null;
                }
                return getTicket(count);
            }
            finally
            {
                if (!driver.ToString().Contains("null"))
                {
                    driver.Quit();
                }
            }

            return data;
        }

        public static CaptchData getTicket()
        {
            return getTicket(1);
        }
    }
}
