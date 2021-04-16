using checkout.Entity.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Qo
{
    class OrderQo
    {
        public ActivityInfoVo activityInfo { get; set; }
        public TicketListItem ticket { get; set; }
        public Dictionary<string, object> apiParams {get;set;}
    }
}
