﻿using checkout.Constants;
using checkout.Entity.Qo;
using checkout.Entity.Vo;
using checkout.Enums;
using checkout.Exceptions;
using checkout.Helper;
using checkout.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Urls = checkout.Constants.Urls;

namespace checkout
{

    public partial class checkoutForm : Form
    {

        private static string MOBILE = "userMobile";

        public delegate void appendTextBox(string value);


        private static string PASSWORD = "pwd";

        private UserService userService;

        public checkoutForm()
        {
            userService = new UserService();
            InitializeComponent();
            searchSelector.DataSource = new string[] {
            "演出名称","演出ID"};
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
   /*         userIdSelector.BeginUpdate();
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
            userIdSelector.EndUpdate();*/
        }

        // 初始化用户地址信息
        protected void initAddress()
        {
 /*           addressSelector.BeginUpdate();
            AddressQo addressQo = new AddressQo
            {
                pageNo = 0,
                pageSize = 10
            };

            RequestUtil.handleAddress(addressQo, addressSelector);
            addressSelector.EndUpdate();*/
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
                if (captchData == null)
                {
                    MessageBox.Show("验证码自动滑块失败");
                    return;
                }
                SendCodeData sendCodeData = new SendCodeData
                {
                    mobile = userMobile,
                    randStr = System.Uri.EscapeDataString(captchData.randstr),
                    ticket = captchData.ticket,
                    type = "1"
                };
                Helpers.writeini(MOBILE, userMobile);
    /*            RequestUtil.post(Constants.Urls.SEND_CODE, sendCodeData, async (res) =>
                {
                    Result<object> result = await JsonSerializer.DeserializeAsync<Result<object>>(res);
                    if (result.isSuccess())
                    {
                        AppendLogText("验证码发送成功");
                    }
                    else
                    {
                        AppendLogText("验证码发送失败：" + result.msg + " " + result.state);
                    }
                });*/
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


            RequestUtil.post(Constants.Urls.LOGIN_PWD, loginData, (async (res) =>
            {
                LogHelpers.write(" 密码登陆：" + res);
                var userRes = await JsonSerializer.DeserializeAsync<Result<UserInfo>>(res);

                if (userRes.isSuccess())
                {
                    string msg = "登陆成功";
                    LogHelpers.write(msg);
                    AppendLogText(msg);
                }
                else
                {
                    string msg = "登陆失败：" + userRes.msg;
                    LogHelpers.write(msg);
                    AppendLogText(msg);
                    return;
                }

                initUserIdInfo();
                initAddress();
                Helpers.writeini("sign", userRes.result.sign);
                Helpers.writeini("st_flpv", userRes.result.st_flpv);
                Helpers.writeini("token", userRes.result.token);
                Helpers.writeini("expireTime", userRes.result.expireTime + "");
                Helpers.writeini("tel", userRes.result.tel);
                Helpers.writeini("userId", userRes.result.userId + "");
            }));


        }


        public void AppendLogText(string msg)
        {
            if (logText.InvokeRequired)
            {
                appendTextBox appendTextBox = new appendTextBox(append);
                Invoke(appendTextBox, new object[] { msg });
            }
            else
            {
                append(msg);
            }
        }

        private void append(string msg)
        {
            logText.AppendText(DateTime.Now.ToString("HH:mm:ss.fff  ") + msg + "\r\n");
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
/*            Result<UserSession> result = RequestUtil.loginByVCode(loginData);

            if (result.isSuccess())
            {
                LogHelpers.write("登陆成功");
                AppendLogText("登陆成功");
            }
            else
            {
                string msg = "登陆失败：" + result.msg + "  " + result.state;
                LogHelpers.write(msg);
                AppendLogText(msg);
                return;
            }
            initUserIdInfo();
            initAddress();
            Helpers.writeini("sign", result.result.session.sign);
            Helpers.writeini("st_flpv", result.result.session.st_flpv);
            Helpers.writeini("token", result.result.session.token);
            Helpers.writeini("expireTime", result.result.session.expireTime + "");
            Helpers.writeini("tel", result.result.session.tel);
            Helpers.writeini("userId", result.result.session.userId + "");*/
        }



        // 刷新信息
        private void refreshInfo_Click(object sender, EventArgs e)
        {
            initUserIdInfo();
            initAddress();
        }

        // 搜索
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Action<Stream> callBack = (async (res) =>
            {
                Result<ActivityInfoList> result = await JsonSerializer.DeserializeAsync<Result<ActivityInfoList>>(res);

                if (result.isSuccess() && result.result.activityInfo.Count > 0)
                {
                    activityComboBox.DataSource = result.result.activityInfo;
                    handleTicket((string)activityComboBox.SelectedValue);
                }
            });
            string search = searchTxt.Text;

    /*        switch (searchSelector.SelectedItem)
            {
                case "演出名称":
                    SearchQo searchQo = new SearchQo
                    {
                        keyword = search,
                        pageNo = 1,
                        pageSize = 20
                    };
                    RequestUtil.get(Constants.Urls.SEARCH, searchQo, callBack);
                    break;
                case "演出ID":
                    RequestUtil.post(Constants.Urls.ACTIVITY_DETAIL, new Dictionary<string, object>() {
                    {"activityId", search },
                    {"userId",userService.getUserId() }
                }, async (res) =>
                {
                    Result<ActivityVo> result = await JsonSerializer.DeserializeAsync<Result<ActivityVo>>(res);
                    activityComboBox.DataSource = new List<ActivityInfoVo>() {
                        { new ActivityInfoVo(){
                        activityId = result.result.activityId,
                        title = result.result.title
                        } }
                    };

                });
                    handleTicket(search);
                    break;
            }*/
        }

        // 处理ticket
        private void handleTicket(string activtyId)
        {
/*            TicketListQo activityDetailQo = new TicketListQo
            {
                activityId = activtyId
            };
            RequestUtil.post(Constants.Urls.TICKET_LIST, activityDetailQo, async (res) =>
            {
                Result<TicketListVo> result = await JsonSerializer.DeserializeAsync<Result<TicketListVo>>(res);


                if (result.isSuccess() && result.result.ticketList.Count > 0)
                {
                    result.result.ticketList.ForEach((item) =>
                    {
                        item.specialActivity = result.result.specialActivity;
                        item.realName = result.result.realName;
                    });
                    ticketList.DataSource = result.result.ticketList;
                }
            });*/

        }

        // 选择的演出切换
        private void activityChange(object sender, EventArgs e)
        {
            handleTicket((string)activityComboBox.SelectedValue);
        }


        // 立即购票
        private void buyNowBtn_Click(object sender, EventArgs e)
        {
            try
            {
                buyCheck();
                buyTicket();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // 定时购票操作
        private void buyTicket(DateTime buyTime)
        {
/*            var orderQo = getOrderQo();
            var ticket = orderQo.ticket;
            var apiParams = orderQo.apiParams;

            for (var i = 0; i < 5; i++)
            {
                Task.Run(() =>
               {
                   buyTime = buyTime.AddMilliseconds(-100);
                   Console.WriteLine(buyTime.ToString("HH:mm:ss.ffff"));
                   var newApiParams = new Dictionary<string, object>(apiParams);
                   if (ticket.specialActivity == 4)
                   {
                       // 需要验证
                       CaptchData captchData = CaptchHelper.getTicket();
                       if (captchData == null)
                       {
                           AppendLogText("验证码滑块失败，请勿频繁滑块或稍后尝试");
                           return;
                       }
                       newApiParams.Add("checkCode", captchData.ticket);
                       newApiParams.Add("randStr", System.Uri.EscapeDataString(captchData.randstr));
                   }
                   RequestUtil.post("app/order/order.json", newApiParams, buyOrderCallback(ticket), buyTime);
               });
            }*/
        }


        // 获取下单参数
        private OrderQo getOrderQo()
        {
            TicketListItem ticket = (TicketListItem)ticketList.SelectedItem;
            ActivityInfoVo activity = (ActivityInfoVo)activityComboBox.SelectedItem;
            AddressInfo addressInfo = (AddressInfo)addressSelector.SelectedItem;
            UserIdInfo userInfo = (UserIdInfo)userIdSelector.SelectedItem;

            Dictionary<string, object> apiParams = new Dictionary<string, object>
            {
                {"goodsType",ticket.goodType},
                {"terminal","android"},
                {"orderDetails[0].goodsType",ticket.goodType},
                {"telephone",userService.getTel()},
                {"orderDetails[0].num",1},
                {"orderDetails[0].activityId",activity.activityId},
                {"orderDetails[0].ticketId",ticket.ticketId},
                {"orderDetails[0].price",ticket.sellingPrice},
                {"orderDetails[0].ticketType",ticket.type},
                {"longitude",0},
                {"latitude",0},
                {"areaCode","86_CN"},
                {"formToken", Helpers.Get32RandomID()},
            };

            // 电子票 or 实体票
            if (ticket.type == 2)
            {
                apiParams.Add("customerName", addressInfo.consignee);
                apiParams.Add("provinceName", addressInfo.provinceName);
                apiParams.Add("cityName", addressInfo.cityName);
                apiParams.Add("address", addressInfo.address);
            }
            else if (ticket.type == 3)
            {
                apiParams.Add("customerName", addressInfo.consignee);
            }

            apiParams.Add("orderType", 1);
            // 支付方式
            apiParams.Add("payPlatName", "alipaymobsc");

            // 优惠券
            if (couponList.SelectedItem != null)
            {
                CouponInfoVo couponInfo = (CouponInfoVo)couponList.SelectedItem;
                apiParams.Add("couponId", couponInfo.id);
            }

            // 实名
            if (ticket.realName == 2 || ticket.realName == 3)
            {
                apiParams.Add("commonPerfomers[0].name", userInfo.name);
                apiParams.Add("commonPerfomers[0].documentType", userInfo.documentType);
                apiParams.Add("commonPerfomers[0].documentNumber", userInfo.documentNumber);
            }
            return new OrderQo()
            {
                ticket = ticket,
                activityInfo = activity,
                apiParams = apiParams
            };
        }

        // 购票检查
        private void buyCheck()
        {
            if (ticketList.SelectedItem == null)
            {
                throw new BusinessException("请先选票");
            }


            if (userIdSelector.SelectedItem == null)
            {
                throw new BusinessException("请先添加或选择常用观影人，以免下单失败");
            }


            if (addressSelector.SelectedItem == null)
            {
                throw new BusinessException("请先添加或选择收货地址，以免下单失败");
            }
        }

        // 立即购票
        private void buyTicket()
        {
            var orderQo = getOrderQo();
            var ticket = orderQo.ticket;
            var apiParams = orderQo.apiParams;

            if (ticket.specialActivity == 4)
            {
                // 需要验证
                CaptchData captchData = CaptchHelper.getTicket();
                if (captchData == null)
                {
                    MessageBox.Show("验证码自动滑块失败");
                    return;
                }
                apiParams.Add("checkCode", captchData.ticket);
                apiParams.Add("randStr", System.Uri.EscapeDataString(captchData.randstr));
            }
            //RequestUtil.post("app/order/order.json", apiParams, buyOrderCallback(ticket));
        }

        private Action<Stream> buyOrderCallback(TicketListItem ticket)
        {
            return new Action<Stream>(async (res) =>
            {
                Result<object> result = await JsonSerializer.DeserializeAsync<Result<object>>(res);
                if (result.isSuccess())
                {
                    LogHelpers.write(ticket.ticketType + "抢票成功");
                    AppendLogText(ticket.ticketType + "抢票成功");
                }
                else
                {
                    LogHelpers.write(ticket.ticketType + "抢票失败：" + result.msg + " " + result.state);
                    AppendLogText(ticket.ticketType + "抢票失败：" + result.msg + " " + result.state);
                }
            });
        }

        // 选票change
        private void ticketChange(object sender, EventArgs e)
        {
            ActivityInfoVo activity = (ActivityInfoVo)activityComboBox.SelectedItem;
            TicketListItem ticket = (TicketListItem)ticketList.SelectedItem;
            if (activity == null || ticket == null)
            {
                return;
            }

            Dictionary<string, object> apiParams = new Dictionary<string, object>() {
                {"pageNo",1 },
                {"pageSize",10 },
                {"sequence",activity.sequence },
                {"totalAmout",ticket.sellingPrice },
                {"type",1 },
            };
  /*          RequestUtil.post(Constants.Urls.COUPON_ORDER_LIST, apiParams, async (res) =>
            {
                Result<CouponList> result = await JsonSerializer.DeserializeAsync<Result<CouponList>>(res);
                if (result.isSuccess())
                {
                    couponList.DataSource = result.result.couponList;
                }
            });*/
        }

        // 定时购票
        private void buyTimeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                buyCheck();
                string txt = buyTimeBtn.Text;
                if (txt == BuyTimeTxt.定时自动购票.ToString())
                {
                    buyTimer.Start();
                    buyTimeBtn.Text = BuyTimeTxt.取消定时.ToString();
                    buyTimePicker.Enabled = false;
                    commonEnable(false);
                    AppendLogText("启动定时，将与：" + buyTimePicker.Text + "自动帮您购票");
                }
                else
                {
                    stopBuy();
                    AppendLogText("您已取消定时购票");
                }
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // 停止购票
        private void stopBuy()
        {
            buyTimer.Stop();
            buyTimeBtn.Text = BuyTimeTxt.定时自动购票.ToString();
            buyTimePicker.Enabled = true;
            commonEnable(true);
        }


        // 设置是否可操作
        private void commonEnable(bool enable)
        {
            searchBtn.Enabled = enable;
            activityComboBox.Enabled = enable;
            ticketList.Enabled = enable;
        }


        // 定时器
        private void buyTimer_Tick(object sender, EventArgs e)
        {
            DateTime buyTime = DateTime.Parse(buyTimePicker.Text);

            if (DateTime.Now.AddMinutes(1).CompareTo(buyTime) >= 0)
            {
                stopBuy();
                buyTicket(buyTime);
            }
        }

        // 捡漏-刷新余票，有票就抢
        private void pickUpBtn_Click(object sender, EventArgs e)
        {
            try
            {

                string text = pickUpBtn.Text;
                if (text == PickUpTxt.开始捡漏.ToString())
                {
                    buyCheck();
                    pickUpBtn.Text = PickUpTxt.暂停.ToString();
                    pickUpTimer.Start();
                    commonEnable(false);
                }
                else
                {
                    pickStop();
                }

            }
            catch (BusinessException ex) { MessageBox.Show(ex.Message); }
        }

        private void pickStop() 
        {
            pickUpBtn.Text = PickUpTxt.开始捡漏.ToString();
            pickUpTimer.Stop();
            commonEnable(true);
        }

        // 捡漏的定时器
        private void pickUpTimer_Tick(object sender, EventArgs e)
        {
            TicketListItem ticketListItem = (TicketListItem)ticketList.SelectedItem;

            TicketListQo activityDetailQo = new TicketListQo
            {
                activityId = ticketListItem.activityId
            };

        /*    RequestUtil.post(Constants.Urls.TICKET_LIST, activityDetailQo, async (res) =>
            {
                Result<TicketListVo> result = await JsonSerializer.DeserializeAsync<Result<TicketListVo>>(res);

                if (result.isSuccess() && result.result.ticketList.Count > 0)
                {
                    result.result.ticketList.ForEach((item) =>
                    {
                        if (item.remainTicket > 0 && item.ticketId == ticketListItem.ticketId)
                        {
                            buyTicket();
                            pickStop();
                        }
                    });
                }
            });*/
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            var result = "https://s2.showstart.com/img/2021/0428/16/30/194ca928d6bf4b28b47b11596dd9cd68_1242_2208_937440.0x0.jpg";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(result));
            StringBuilder stringBuilder = new StringBuilder();
            for (var i = 0; i < s.Length; ++i) {
               var res =  s[i] & 255;
                stringBuilder.Append(res.ToString("X2"));
            }
            Console.WriteLine(stringBuilder.ToString());
        }

        private void makeToken(object sender, EventArgs e)
        {

            RequestUtil.post(Urls.MAKE_TOKEN,new Object(), async (res) => {
                Result<object> result = await JsonSerializer.DeserializeAsync<Result<object>>(res);
                if (result.isSuccess()) {
                }
            });
        }
    }
}
