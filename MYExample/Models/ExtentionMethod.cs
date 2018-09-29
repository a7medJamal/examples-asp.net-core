﻿using System;
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
     
   
    }
}