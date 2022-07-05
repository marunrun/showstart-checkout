using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Vo
{
    public class Result<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public string invalidParams { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isHasResult { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool nd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string state { get; set; }
        public bool success { get; set; }

        public bool isSuccess() 
        {
            return this.success == true || this.state == "1";
        }
    }
}
