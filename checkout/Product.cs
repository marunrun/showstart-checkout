
namespace checkout
{
    class Product
    {
        public double price { get; set; }
        public int count { get; set; }
        public string id { get; set; }
        public string name { get; set; }

        public Product(string id, double price, int count,string name)
        {
            this.id = id;
            this.price = price;
            this.count = count; 
            this.name = name; 
        }
    }
}
