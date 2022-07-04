using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Vo
{

    class TicketListVo
    {
        //public int realName { get; set; }
        public List<Session> sessions { get; set; }
        public string showTime { get; set; }
        //public string helpUrl { get; set; }
        //public int specialActivity { get; set; }
        //public PayType payType { get; set; }

    }

    public class Session
    {
        public string sessionId { get; set; }
        public string sessionName { get; set; }

        public int isConfirmedStartTime { get; set; }


        public List<TicketListItem> ticketList { get; set; }

    }

    public class TicketListItem
    {
        public string ticketId { get; set; }
        public string ticketType { get; set; }
        public double sellingPrice { get; set; }
        public string costPrice { get; set; }
        public int ticketNum { get; set; }
        public int validateType { get; set; }
        public string time { get; set; }
        public string instruction { get; set; }
        public int countdown { get; set; }
        public int remainTicket { get; set; }
        public int saleStatus { get; set; }
        public string activityId { get; set; }
        public int goodType { get; set; }
        public string telephone { get; set; }
        public string areaCode { get; set; }
        public int limitBuyNum { get; set; }
        public int canBuyNum { get; set; }
        public string cityName { get; set; }
        public int unPayOrderNum { get; set; }
        public int type { get; set; }
        public int buyType { get; set; }
        public int canAddGoods { get; set; }
        public int ticketRecordStatus { get; set; }
        public int startSellNoticeStatus { get; set; }
        public bool showRuleTip { get; set; }
        public long startTime { get; set; }
        public string showTime { get; set; }
        public int memberNum { get; set; }
        public string text { get {
                return ticketType + "库存：" + remainTicket;
        } }

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
