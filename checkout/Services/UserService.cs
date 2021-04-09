using checkout.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Services
{
    class UserService
    {
        public Boolean isLogin()
        {
            string tel = getTel();
            string expireTime = getExpireTime();
            string sign = getSign();

            // 如果登陆过
            if (tel != "" && sign != "" && Helpers.TicksToDate(expireTime).CompareTo(DateTime.Now) > 0)
            {
                return true;
            }

            return false;
        }

        public string getTel()
        {
            return Helpers.readIni("tel", "");
        }
        public string getSign()
        {
            return Helpers.readIni("sign", "");
        }

        public string getUserId()
        {
            return Helpers.readIni("userId", "");

        }

        public string getExpireTime()
        {
            return Helpers.readIni("expireTime", "");
        }
    }
}
