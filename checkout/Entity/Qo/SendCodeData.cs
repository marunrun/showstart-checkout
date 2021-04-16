using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Qo
{
    class SendCodeData
    {
        /// <summary>
        /// 
        /// </summary>
        public string areaCode = "86_CN";
        /// <summary>
        /// 
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string randStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ticket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }

    }
}
