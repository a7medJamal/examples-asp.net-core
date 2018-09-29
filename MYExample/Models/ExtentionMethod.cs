using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYExample.Models
{
    public static class ExtentionMethod
    {
        public static decimal PriceTotal(this ShoppingCart cartparam)
        {
            decimal total = 0;
            foreach (Product pro in cartparam.products)
                total += pro.Price;
            return total;

        }
        public static decimal PricetotalIE(this IEnumerable<Product> productsIE)
        {
            decimal total = 0;
            foreach (Product pro in productsIE)
                total += pro.Price;
            return total;
        }
     public static IEnumerable<Product > FilterByCategory(this IEnumerable<Product> productEnum , string categoryparam)
        {
            foreach (Product pro in productEnum)
                if (pro.Category == categoryparam)
                   yield return pro;
        }
    }
}
