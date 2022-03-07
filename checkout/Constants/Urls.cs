using checkout.Entity.Qo;

namespace checkout.Constants
{
    class Urls
    {

        // 搜索列表
        public static RequestQo SEARCH = new RequestQo
        {
            action = "/app/activity/search",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "app/00000000j2rN"
        };


        // 活动详情
        public static RequestQo ACTIVITY_DETAIL = new RequestQo
        {
            action = "/app/activity/details",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "app/000000000000"
        };

        // 身份证
        public static RequestQo COMMON_PERFORMER = new RequestQo
        {
            action = "/app/commonPerformer/list",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "app/00000000lcvj"
        };

        // 收货地址
        public static RequestQo ADDRESS_LIST = new RequestQo
        {
            action = "/app/address/list",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "app/00000000lcvj"
        };

        // 下单
        public static RequestQo ORDER_ORDER = new RequestQo
        {
            action = "/order/order",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "appnj/00000000lcvj"
        };


        // 票列表
        public static RequestQo TICKET_LIST = new RequestQo
        {
            action = "/app/activity/ticket/list",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "app/00000000lcvj"
        };


        // 密码登陆
        public static RequestQo LOGIN_PWD = new RequestQo
        {
            action = "/app/user/login",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "app/000000000000"
        };


        // 获取token
        public static RequestQo MAKE_TOKEN = new RequestQo
        {
            action = "/common/user/maketoken",
            bol = true,
            type = "REQUEST_QUERY",
            uri  = "app/00000000lcvj"
        };

        // 优惠券
        public static RequestQo COUPON_ORDER_LIST = new RequestQo
        {
            action = "/coupon/order_list",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "appnj/00000000lcvj"
        };

        // 验证码登陆
        public static RequestQo VC_LOGIN = new RequestQo
        {
            action = "/app/user/vc_login",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "app/000000000000"
        };

        // 发送验证码
        public static RequestQo SEND_CODE = new RequestQo
        {
            action = "/app/msg/verifyCode",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "app/000000000000"
        };

        // 订单结果
        public static RequestQo ORDER_RESULT = new RequestQo
        { 
            action = "/order/getCoreOrderResult",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "appnj/02000000lcvj",
        };
    }


}
