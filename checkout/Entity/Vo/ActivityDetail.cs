using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Vo
{
    class ActivityDetail
    {
        public ActivityVo activityVo { get; set; }

    }

    class ActivityVo
    {
        public string activityId { get; set; }

        public string title { get; set; }

    }
}
