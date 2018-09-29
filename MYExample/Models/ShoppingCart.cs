using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYExample.Models
{
    public class ShoppingCart : IEnumerable<Product>
    {
       public List<Product> products { set; get; }

        public IEnumerator<Product> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
