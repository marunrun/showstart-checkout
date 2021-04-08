using checkout.Entity;
using checkout.Helper;
using checkout.Services;
using Newtonsoft.Json;
using Microsoft.Edge.SeleniumTools;
using System;

using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Fiddler;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.Support.UI;

namespace checkout
{

    public partial class checkoutForm : Form
    {
        static Fiddler.Proxy oSecureEndpoint;
        static string sSecureEndpointHostname = "localhost";
        static int iSecureEndpointPort = 7777;


        private static string MOBILE = "userMobile";

        private static string PASSWORD = "pwd";

        private UserService userService;

        public checkoutForm()
        {
            this.userService = new UserService();

            InitializeComponent();
            initMobileAndPwd();
        }

        // 初始化，账号，密码等信息
        public void initMobileAndPwd()
        {
            mobile.Text = Helpers.readIni(MOBILE, "");
            password.Text = Helpers.readIni(PASSWORD, "");

            if (userService.isLogin())
            {
                LogHelpers.write("您已登陆：" + userService.getTel(), logText);
            }
        }

        private void buy_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        // 发送验证码
        private void sendCode_Click(object sender, EventArgs e)
        {
            string userMobile = mobile.Text;

            if (userMobile.Length == 0 || userMobile.Length != 11)
            {
                MessageBox.Show("手机号格式错误");
                return;
            }

            // 滑块验证
            CaptchData captchData = CaptchHelper.getTicket();

            SendCodeData sendCodeData = new SendCodeData
            {
                mobile = userMobile,
                randStr = Uri.EscapeDataString(captchData.randstr),
                ticket = captchData.ticket,
                type = "1"
            };
            Helpers.writeini(MOBILE, userMobile);

            string res = RequestUtil.sign(JsonConvert.SerializeObject(sendCodeData));
            Result<object> result = RequestUtil.sendCode(res);
            if (result.isSuccess())
            {
                LogHelpers.write("验证码发送成功", logText);
            }
            else
            {
                LogHelpers.write("验证码发送失败：" + result.msg, logText);
                return;
            }

        }

        public void writeLog(string msg)
        {
            logText.AppendText(msg);
        }

        // 密码登陆
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
            LoginData loginData = new LoginData
            {
                name = userMobile,
                password = pwd,
            };

            string res = RequestUtil.sign(JsonConvert.SerializeObject(loginData));
            Helpers.writeini(MOBILE, userMobile);
            Helpers.writeini(PASSWORD, pwd);


            Result<UserInfo> userRes = RequestUtil.loginByPwd(res);
            LogHelpers.write(" 密码登陆：" + userRes);
            if (userRes.isSuccess())
            {
                LogHelpers.write("登陆成功", logText);
            }
            else
            {
                LogHelpers.write("登陆失败：" + userRes.msg, logText);
                return;
            }
            Helpers.writeini("sign", userRes.result.sign);
            Helpers.writeini("st_flpv", userRes.result.st_flpv);
            Helpers.writeini("token", userRes.result.token);
            Helpers.writeini("expireTime", userRes.result.expireTime + "");
            Helpers.writeini("tel", userRes.result.tel);
            Helpers.writeini("userId", userRes.result.userId + "");
        }


        // 验证码登陆
        private void login_Click(object sender, EventArgs e)
        {
            string userMobile = mobile.Text;
            if (userMobile.Length == 0 || userMobile.Length != 11)
            {
                MessageBox.Show("手机号格式错误");
                return;
            }
            string vcode = code.Text;
            if (vcode.Length == 0)
            {
                MessageBox.Show("验证码不得为空");
                return;
            }

            CodeLoginData loginData = new CodeLoginData
            {
                phone = userMobile,
                verifyCode = vcode,
            };
            // 加签
            string res = RequestUtil.sign(JsonConvert.SerializeObject(loginData));
            // 发送请求
            Result<UserSession> result = RequestUtil.loginByVCode(res);

            if (result.isSuccess())
            {
                LogHelpers.write("登陆成功", logText);
            }
            else
            {
                LogHelpers.write("登陆失败：" + result.msg, logText);
                return;
            }

            Helpers.writeini("sign", result.result.session.sign);
            Helpers.writeini("st_flpv", result.result.session.st_flpv);
            Helpers.writeini("token", result.result.session.token);
            Helpers.writeini("expireTime", result.result.session.expireTime + "");
            Helpers.writeini("tel", result.result.session.tel);
            Helpers.writeini("userId", result.result.session.userId + "");
        }

        private void mobile_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
