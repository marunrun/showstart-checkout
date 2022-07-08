using checkout.Entity.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity
{
    public class BuyTicketDto
    {
        public TicketListItem ticket;
        public ActivityInfoVo activity;
        public AddressInfo addressInfo;
        public CouponInfoVo couponInfo;
        public List<UserIdInfo> userList;
        public int buyNum;


    }

}
