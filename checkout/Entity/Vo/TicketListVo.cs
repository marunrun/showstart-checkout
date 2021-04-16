using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Vo
{

    class TicketListVo
    {
        public int realName { get; set; }
        public List<TicketListItem> ticketList { get; set; }
        public string showTime { get; set; }
        public string helpUrl { get; set; }
        public int specialActivity { get; set; }
        public PayType payType { get; set; }

    }
    public class TicketListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string activityId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alternateEndTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int alternateLimitNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alternateUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string areaCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int buyGroupType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int canAddGoods { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int canBuyNum { get; set; }
        /// <summary>
        /// 杭州
        /// </summary>
        public string cityName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int costPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string entityMailInstruction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string entityPickupInstruction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double entityPickupLatitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double entityPickupLongitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string exchangeRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int goodType { get; set; }
        /// <summary>
        /// 限量
        /// </summary>
        public string instruction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isShowAlternateButton { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int limitBuyNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pickupAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pickupDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public long pickupEndTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public long pickupStartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pickupTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int remainTicket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int saleStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double sellingPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool showRuleTip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showStartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int startSellNoticeStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string teamRemark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string telephone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ticketId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ticketNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ticketRecordStatus { get; set; }
        /// <summary>
        /// 早鸟票
        /// </summary>
        public string ticketType { get; set; }
        /// <summary>
        /// 2021.03.15 00:00停售
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int unPayOrderNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int waitingAlternateNum { get; set; }

        public string text { get {
                return ticketType + "库存：" + remainTicket;
            } }

        public int specialActivity  { get; set; }
        public int realName { get; set; }


    }

    public class PayType
    {
        /// <summary>
        /// 
        /// </summary>
        public int alipay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int paypal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int wxpay { get; set; }
    }
}
