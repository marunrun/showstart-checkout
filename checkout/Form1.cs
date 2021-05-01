using checkout.Entity.Qo;
using checkout.Entity.Vo;
using checkout.Enums;
using checkout.Exceptions;
using checkout.Helper;
using checkout.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            userService = UserService.getInstance();
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
            userService.sign = Helpers.readIni("sign", "");
            userService.userId = long.Parse(Helpers.readIni("userId", "0"));
            userService.tel = Helpers.readIni("tel", "");
        }

        // 初始化用户身份证信息
        protected void initUserIdInfo()
        {
            userIdSelector.BeginUpdate();

            RequestUtil.post(Urls.COMMON_PERFORMER, new object(), (res) =>
            {
                Result<List<UserIdInfo>> result = JsonConvert.DeserializeObject<Result<List<UserIdInfo>>>(res);
                if (result.isSuccess())
                {
                    userIdSelector.DataSource = result.result;
                }
                else 
                {
                }
            });

            userIdSelector.EndUpdate();
        }

        // 初始化用户地址信息
        protected void initAddress()
        {
            addressSelector.BeginUpdate();
            AddressQo addressQo = new AddressQo
            {
                pageNo = 0,
                pageSize = 10,
            };
            RequestUtil.post(Urls.ADDRESS_LIST, addressQo, (res) =>
            {
                Result<List<AddressInfo>> result = JsonConvert.DeserializeObject<Result<List<AddressInfo>>>(res);
                if (result.isSuccess())
                {
                    addressSelector.DataSource = result.result;
                }
            });
            addressSelector.EndUpdate();
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
                    randStr = Uri.EscapeDataString(captchData.randstr),
                    ticket = captchData.ticket,
                    type = "1",
                    areaCode = "86_CN",
                };
                Helpers.writeini(MOBILE, userMobile);
                RequestUtil.post(Urls.SEND_CODE, sendCodeData, (res) =>
               {
                   Result<object> result = JsonConvert.DeserializeObject<Result<object>>(res);
                   if (result.isSuccess())
                   {
                       AppendLogText("验证码发送成功");
                   }
                   else
                   {
                       AppendLogText("验证码发送失败：" + result.msg + " " + result.state);
                   }
               });
            });

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
            Helpers.writeini("sign", "");
            RequestUtil.post(Urls.LOGIN_PWD, loginData, (res) =>
           {
               LogHelpers.write(" 密码登陆：" + res);
               Result<UserInfo> result = JsonConvert.DeserializeObject<Result<UserInfo>>(res);
               if (result.isSuccess())
               {
                   loginSuccessCallBack(result.result);
               }
               else
               {
                   string msg = "登陆失败：" + result.msg + "  " + result.state;
                   LogHelpers.write(msg);
                   AppendLogText(msg);
               }
           });
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
                areaCode = "86_CN",
                cityCode = "571"
            };
            // 发送请求
            RequestUtil.post(Urls.VC_LOGIN, loginData, (res) =>
            {
                Result<UserSession> result = JsonConvert.DeserializeObject<Result<UserSession>>(res);
                if (result.isSuccess())
                {
                    loginSuccessCallBack(result.result.session);
                }
                else
                {
                    string msg = "登陆失败：" + result.msg + "  " + result.state;
                    LogHelpers.write(msg);
                    AppendLogText(msg);
                }
            });
        }

        // 登陆成功的回调
        private void loginSuccessCallBack(UserInfo userInfo)
        {
            LogHelpers.write("登陆成功");
            AppendLogText("登陆成功");

            userService.sign = userInfo.sign;
            userService.userId = userInfo.userId;
            userService.tel = userInfo.tel;
            Helpers.writeini("sign", userInfo.sign);
            Helpers.writeini("userId", userInfo.userId.ToString());
            Helpers.writeini("tel", userInfo.tel);
            initUserIdInfo();
            initAddress();
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
            Action<string> callBack = (res) =>
            {
                Result<ActivityInfoList> result = JsonConvert.DeserializeObject<Result<ActivityInfoList>>(res);

                if (result.isSuccess() && result.result.activityInfo.Count > 0)
                {
                    activityComboBox.DataSource = result.result.activityInfo;
                    handleTicket((string)activityComboBox.SelectedValue);
                }
            };
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
                    RequestUtil.post(Urls.SEARCH, searchQo, callBack);
                    break;
                case "演出ID":
                    RequestUtil.post(Urls.ACTIVITY_DETAIL, new Dictionary<string, object>() {
                    {"activityId", search },
                    {"keyId","" }
                }, (res) =>
               {
                   Result<ActivityVo> result = JsonConvert.DeserializeObject<Result<ActivityVo>>(res);
                   activityComboBox.DataSource = new List<ActivityInfoVo>() {
                        { new ActivityInfoVo(){
                        activityId = result.result.activityId,
                        title = result.result.title
                        } }
                   };

               });
                    handleTicket(search);
                    break;
            }
        }

        // 处理ticket
        private void handleTicket(string activtyId)
        {
            TicketListQo activityDetailQo = new TicketListQo
            {
                activityId = activtyId
            };
            RequestUtil.post(Urls.TICKET_LIST, activityDetailQo, (res) =>
            {
                Result<TicketListVo> result = JsonConvert.DeserializeObject<Result<TicketListVo>>(res);

                if (result.isSuccess() && result.result.ticketList.Count > 0)
                {
                    result.result.ticketList.ForEach((item) =>
                    {
                        item.specialActivity = result.result.specialActivity;
                        item.realName = result.result.realName;
                    });
                    ticketList.DataSource = result.result.ticketList;
                }
            });

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
            var orderQo = getOrderQo();
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
                       newApiParams.Add("randStr", Uri.EscapeDataString(captchData.randstr));
                   }
                   RequestUtil.post(Urls.ORDER_ORDER, newApiParams, buyOrderCallback(ticket), buyTime);
               });
            }
        }


        // 获取下单参数
        private OrderQo getOrderQo()
        {
            TicketListItem ticket = (TicketListItem)ticketList.SelectedItem;
            ActivityInfoVo activity = (ActivityInfoVo)activityComboBox.SelectedItem;
            AddressInfo addressInfo = (AddressInfo)addressSelector.SelectedItem;
            UserIdInfo userInfo = (UserIdInfo)userIdSelector.SelectedItem;
            CouponInfoVo couponInfo = (CouponInfoVo)couponList.SelectedItem;
            var amountPayable = ticket.sellingPrice;
            // 优惠券
            if (couponInfo != null)
            {
                amountPayable = amountPayable - couponInfo.price;
            }

            List<OrderPlaceGoodsBean> lists = new List<OrderPlaceGoodsBean>();
            OrderPlaceGoodsBean orderPlaceGoodsBean = new OrderPlaceGoodsBean();
            orderPlaceGoodsBean.goodsType = 1;
            orderPlaceGoodsBean.skuType = 1;
            if (ticket.type == 2 || ticket.type == 3)
            {
                orderPlaceGoodsBean.skuType = ticket.type;
            }
            orderPlaceGoodsBean.num = 1;
            orderPlaceGoodsBean.goodsId = ticket.activityId;
            orderPlaceGoodsBean.skuId = ticket.ticketId;
            orderPlaceGoodsBean.cartId = "";
            orderPlaceGoodsBean.price = ticket.sellingPrice.ToString();
            lists.Add(orderPlaceGoodsBean);

            Dictionary<string, object> apiParams = new Dictionary<string, object>
            {
                {"telephone",userService.tel},
                {"customerName",addressInfo.consignee},
                // 实际支付金额
                {"amountPayable",amountPayable },
                // 总价
                {"totalAmount",ticket.sellingPrice },
                // 折扣
                {"discount",couponInfo == null ? 0 :couponInfo.price},
                {"source","0"},
                // 订单详情
                {"orderDetails",lists},
                // 地区
                {"areaCode","86_CN"},
                {"customerRemark",""},
                {"longitude",0},
                {"latitude",0},
            };

            // 电子票 or 实体票
            if (ticket.type == 2)
            {
                apiParams.Add("provinceName", addressInfo.provinceName);
                apiParams.Add("cityName", addressInfo.cityName);
                apiParams.Add("address", addressInfo.address);
            }

            if (couponInfo != null)
            {
                apiParams.Add("couponId", couponInfo.id);
            }


            // 实名
            if (ticket.realName == 2 || ticket.realName == 3)
            {
                apiParams.Add("commonPerfomerIds", new long[] { userInfo.id });
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
                apiParams.Add("randStr", Uri.EscapeDataString(captchData.randstr));
            }
            RequestUtil.post(Urls.ORDER_ORDER, apiParams, buyOrderCallback(ticket));
        }

        // 购票的回调
        private Action<string> buyOrderCallback(TicketListItem ticket)
        {
            return new Action<string>((res) =>
            {
                Result<object> result = JsonConvert.DeserializeObject<Result<object>>(res);
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
                {"activityId",ticket.activityId},
                {"totalAmount",ticket.sellingPrice },
                {"pageNo",1},
                {"pageSize",20 },
                {"type",1 },
            };
            RequestUtil.post(Urls.COUPON_ORDER_LIST, apiParams, (res) =>
           {
               Result<CouponList> result = JsonConvert.DeserializeObject<Result<CouponList>>(res);
               if (result.isSuccess())
               {
                   couponList.DataSource = result.result.couponList;
               }
           });
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
                buyTicket(buyTime);
                stopBuy();
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

            RequestUtil.post(Urls.TICKET_LIST, activityDetailQo, (res) =>
           {
               Result<TicketListVo> result = JsonConvert.DeserializeObject<Result<TicketListVo>>(res);

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
           });
        }

        // 生成token
        private void makeToken(object sender, EventArgs e)
        {
            RequestUtil.post(Urls.MAKE_TOKEN, new object(), (res) =>
            {
                Result<string> result = JsonConvert.DeserializeObject<Result<string>>(res);
                if (result.isSuccess())
                {
                    Helpers.writeini(RequestUtil.DATA_KEY, result.result);
                    AppendLogText("key 加载成功");
                }
                else
                {
                    AppendLogText("key 加载失败");
                }
            });
        }


        #region 日志操作
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

        public void writeLog(string msg)
        {
            logText.AppendText(msg);
        }
        #endregion
    }
}
