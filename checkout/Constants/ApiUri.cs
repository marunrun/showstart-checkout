using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Constants
{
    class ApiUri
    {
        public const string SEARCH = "app/activity/search.json";
        public const string ACTIVITY_DETAIL = "app/activity/details.json";
        public const string TICKET_LIST = "app/activity/ticket/list.json";
        public const string LOGIN_PWD = "app/user/login.json";
        public const string COUPON_ORDER_LIST = "app/coupon/order_list.json";
        public const string SEND_CODE = "app/sms/verifyCode.json";
    }
}
