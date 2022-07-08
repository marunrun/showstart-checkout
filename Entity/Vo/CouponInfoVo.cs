using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Vo
{

    class CouponList {
        public List<CouponInfoVo> couponList { set; get; }
    }

    public class CouponInfoVo
    {
        /// <summary>
        /// 
        /// </summary>
        public string limitActivity { get; set; }
        /// <summary>
        /// 未使用
        /// </summary>
        public string statusDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float subtractPrice { get; set; }
        /// <summary>
        /// 西湖音乐节购票优惠券
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// APP使用
        /// </summary>
        public string terminal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long beginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long endTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timeRange { get; set; }
    }
}
