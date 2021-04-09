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

namespace checkout.Helper
{
    class CaptchHelper
    {
        private static EdgeDriver driver;

        static EdgeDriver getDriver()
        {
            if (driver == null)
            {
                EdgeOptions edgeOptions = new EdgeOptions
                {
                    UseChromium = true
                };
                driver = new EdgeDriver(edgeOptions);

            }

            return driver;
        }

        public static CaptchData getTicket()
        {
            EdgeDriver driver = getDriver();
            // 跳转到滑块页
            driver.Navigate().GoToUrl("file://" + Directory.GetCurrentDirectory() + "/Res/Tcaptch.html");
            // 隐式等待10s
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // 切换到滑块对应的iframe
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver.SwitchTo().Frame(driver.FindElementById("tcaptcha_iframe"));
            Thread.Sleep(500);
            // 执行js代码
            js.ExecuteScript(File.ReadAllText(Directory.GetCurrentDirectory() + "/Res/slide.js"));

            try
            {
                // 等待ticket成功出现
                new WebDriverWait(driver, TimeSpan.FromSeconds(6)).Until((d) =>
                {
                    driver.SwitchTo().ParentFrame();
                    return d.FindElement(By.Id("ticket")).GetProperty("text");
                });
            }
            catch (Exception)
            {
                return getTicket();
            }


            // 再切回父iframe
            driver.SwitchTo().ParentFrame();
            return new CaptchData
            {
                ticket = driver.FindElementById("ticket").GetProperty("text"),
                randstr = driver.FindElementById("randstr").GetProperty("text")
            };
        }
    }
}
