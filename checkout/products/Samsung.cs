using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.products
{
    class Samsung : Product
    {
        public Samsung(string id, double price, int count, string name) : base(id, price, count, name)
        {
        }
    }
}
