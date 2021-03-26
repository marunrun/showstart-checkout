using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.products
{
    class Acer : Product
    {
        public Acer(string id, double price, int count, string name) : base(id, price, count, name)
        {
        }
    }
}
