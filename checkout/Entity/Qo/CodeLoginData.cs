using checkout.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Qo
{
    class CodeLoginData
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
        public string formToken = "";
        /// <summary>
        /// 
        /// </summary>
        public string ip = Helpers.GetIP();
        /// <summary>
        /// 
        /// </summary>
        public double latitude = 0.0;
        /// <summary>
        /// 
        /// </summary>
        public double longitude = 0.0;
        /// <summary>
        /// 
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string verifyCode { get; set; }
    }
}
