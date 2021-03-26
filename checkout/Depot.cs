using checkout.enums;
using checkout.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout
{
    class Depot
    {

        public static Dictionary<ProductEnum, Product> products = new Dictionary<ProductEnum, Product>()
        {
            { ProductEnum.Acer, new Acer(Guid.NewGuid().ToString(),1999.0,0,"宏基电脑")},
            { ProductEnum.Samsung,new Samsung(Guid.NewGuid().ToString(),2999.0,0,"三星手机")}
        };



        /// <summary>
        /// 进货
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        public static void inProduct(ProductEnum type, int count)
        {
            Product product = products[type];
            product.count += count;
            products.Add(type, product);
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        public static void outProduct(ProductEnum type, int count)
        {
            Product product = products[type];
            product.count -= count;
            if (product.count < 1)
            {
                throw new ArgumentOutOfRangeException("库存不足");
            }
            products.Add(type, product);
        }

        /// <summary>
        /// 展示产品信息
        /// </summary>
        /// <returns></returns>
        public static string showProducts()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Product product in products.Values) 
            {
                stringBuilder.AppendLine($"{product.name} 单价：{product.price} 库存：{product.count} 件");
            }
            return stringBuilder.ToString();
        }

       
    }
}
