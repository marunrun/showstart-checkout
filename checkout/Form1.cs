using checkout.Entity;
using checkout.Helper;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace checkout
{
    public partial class Form1 : Form
    {

        private static string MOBILE = "userMobile";

        private static string PASSWORD = "pwd";

        public Form1()
        {
            InitializeComponent();
            initMobileAndPwd();
        }

        // 初始化，账号，密码
        public void initMobileAndPwd()
        {
            mobile.Text = Helpers.readIni(MOBILE, "");
            password.Text = Helpers.readIni(PASSWORD, "");
        }

        private void buy_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void sendCode_Click(object sender, EventArgs e)
        {
            String userMobile = mobile.Text;


        }

        public void writeLog(string msg)
        {
            logText.AppendText(msg);
        }

        private void pwdLogin_Click(object sender, EventArgs e)
        {
            string userMobile = mobile.Text;

            if (userMobile.Length == 0 || userMobile.Length != 11)
            {
                MessageBox.Show("手机号格式错误");
                return;
            }
            string pwd = password.Text;
            if (pwd.Length == 0)
            {
                MessageBox.Show("密码不得为空");
                return;
            }
            LoginData loginData = new LoginData();
            loginData.areaCode = "86_CN";
            loginData.cityCode = "571";
            loginData.deviceType = 4;
            loginData.jsessionId = Helpers.Get32RandomID();
            loginData.latitude = 30.275146;
            loginData.longitude = 120.12643;
            loginData.loginIp = Helpers.GetIP();
            loginData.name = userMobile;
            loginData.password = pwd;

            string res = RequestUtil.Sign(JsonConvert.SerializeObject(loginData));
            Helpers.writeini(MOBILE, userMobile);
            Helpers.writeini(PASSWORD, pwd);
            string v = RequestUtil.loginByPwd(res);

            Console.WriteLine(v);
            LogHelpers.write(v, logText);

        }


    }
}
