using checkout.Constants;
using checkout.Entity;
using checkout.Entity.Qo;
using checkout.Entity.Vo;
using checkout.Enums;
using checkout.Helper;
using checkout.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace checkout
{

    public partial class checkoutForm : Form
    {

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
        }

        // 初始化用户身份证信息
        protected async void initUserIdInfo()
        {

            userIdSelector.BeginUpdate();
            getUserIdListQo getUserIdListQo = new getUserIdListQo
            {
                userId = new UserService().getUserId()
            };
            //string v = RequestUtil.sign(JsonConvert.SerializeObject());
            Result<System.Collections.Generic.List<UserIdInfo>> result = await RequestUtil.getUserIdInfo(getUserIdListQo);

            if (result.isSuccess())
            {
                userIdSelector.DataSource = result.result;
            }
            userIdSelector.EndUpdate();
        }

        // 初始化用户地址信息
        protected void initAddress()
        {
            addressSelector.BeginUpdate();
            AddressQo addressQo = new AddressQo
            {
                pageNo = 0,
                pageSize = 10
            };

            RequestUtil.handleAddress(addressQo, addressSelector);
            addressSelector.EndUpdate();
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

            Task.Run(() =>
            {
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

                RequestUtil.sendCode(sendCodeData, logText);
            });

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

            Helpers.writeini(MOBILE, userMobile);
            Helpers.writeini(PASSWORD, pwd);


            Result<UserInfo> userRes = RequestUtil.loginByPwd(loginData);
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
            // 发送请求
            Result<UserSession> result = RequestUtil.loginByVCode(loginData);

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



        // 刷新信息
        private void refreshInfo_Click(object sender, EventArgs e)
        {
            initUserIdInfo();
            initAddress();
            object selectedItem = addressSelector.SelectedItem;
            Console.WriteLine(selectedItem);
        }

        // 搜索
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Action<string> callBack = ((res) =>
            {
                Console.WriteLine(res);
                Result<ActivityInfoList> result = (Result<ActivityInfoList>)JsonConvert.DeserializeObject(res, typeof(Result<ActivityInfoList>));

                if (result.isSuccess() && result.result.activityInfo.Count > 0)
                {
                    activityComboBox.DataSource = result.result.activityInfo;
                }
            });
            string search = searchTxt.Text;
            switch (searchSelector.SelectedItem)
            {
                case "演出名称":
                    SearchQo searchQo = new SearchQo
                    {
                        keyword = search,
                        pageNo = 1,
                        pageSize = 20
                    };
                    Console.WriteLine("名称搜索");
                    RequestUtil.get(ApiUri.SEARCH, searchQo, callBack);
                    break;
                case "演出ID":
                    handleActivity(search);
                    break;
            }
        }

        // 
        private void handleActivity(string activtyId)
        {
            TicketListQo activityDetailQo = new TicketListQo
            {
                activityId = activtyId
            };
            RequestUtil.post(ApiUri.TICKET_LIST, activityDetailQo, ((res) =>
            {
                
            }));

        }

        // 选择的演出切换
        private void activityChange(object sender, EventArgs e)
        {
            ActivityInfoVo activityInfo = (ActivityInfoVo)activityComboBox.SelectedItem;
            handleActivity(activityInfo.activityId);
        }
    }
}
