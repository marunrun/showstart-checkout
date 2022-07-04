using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Entity.Qo
{
    class RequestQo
    {

        public string action { get; set; }
        public bool bol { get; set; }
        public string type { get; set; }

        public string uri { get; set; }

        public string Geturi()
        {
            return prefix + Helper.Helpers.transtoPath(this.pathType, this.sessionId);
        }

        public void Seturi(string value)
        {
            uri = value;
        }



        public string pathType { get; set; } = "";

        public string sessionId { get; set; } = "";

        public string prefix { get; set; } = "/app/";

    }
}
