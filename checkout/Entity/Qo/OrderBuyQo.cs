using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Qo
{
    class OrderBuyQo
    {
        /// <summary>
        /// 
        /// </summary>
        public string areaCode = "86_CN";

        /// <summary>
        /// 
        /// </summary>
        public string goodsType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int latitude = 0;
        /// <summary>
        /// 
        /// </summary>
        public int longitude = 0;

        public string orderType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string payPlatName  = "alipaymobsc";

        /// <summary>
        /// 
        /// </summary>
        public string telephone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string terminal = "android";
    }

    class OrderPlaceGoodsBean 
    {
        public String cartId { get; set; }
        public String goodsId { get; set; }
        public int goodsType { get; set; }
        public int num { get; set; }
        public String price { get; set; }
        public String skuId { get; set; }
        public int skuType { get; set; }
    }
}
