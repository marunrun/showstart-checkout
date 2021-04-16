using checkout.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Qo
{
    class LoginData
    {

        /// <summary>
        /// 
        /// </summary>
        public string areaCode = "86_CN";
        /// <summary>
        /// 
        /// </summary>
        public string cityCode = "10";
        /// <summary>
        /// 
        /// </summary>
        public int deviceType = 4;
        /// <summary>
        /// 
        /// </summary>
        public string jsessionId = Helpers.Get32RandomID();
        /// <summary>
        /// 
        /// </summary>
        public double latitude = 0.0;
        /// <summary>
        /// 
        /// </summary>
        public string loginIp =  Helpers.GetIP();
        /// <summary>
        /// 
        /// </summary>
        public double longitude = 0.0;
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string password { get; set; }
    }
}
