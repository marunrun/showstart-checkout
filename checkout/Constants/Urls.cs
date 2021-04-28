using checkout.Entity.Qo;

namespace checkout.Constants
{
    class Urls
    {
        public const string SEARCH = "app/activity/search.json";
        public const string ACTIVITY_DETAIL = "app/activity/details.json";
        public const string TICKET_LIST = "app/activity/ticket/list.json";
        public static RequestQo LOGIN_PWD = new RequestQo
        {
            action = "/app/user/login",
            bol = false,
            type = "REQUEST_QUERY",
            uri = "app/000000000000"
        };

        public static RequestQo MAKE_TOKEN = new RequestQo
        {
            action = "/common/user/maketoken",
            bol = true,
            type = "REQUEST_QUERY",
            uri  = "app/000000000000"
        };

        public const string COUPON_ORDER_LIST = "app/coupon/order_list.json";
        public const string SEND_CODE = "app/sms/verifyCode.json";
    }


}
