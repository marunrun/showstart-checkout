using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Qo
{
    class SearchQo
    {
        public string keyword { get; set; }

        public int pageSize { get; set; }

        public int pageNo { get; set; }
    }
}
