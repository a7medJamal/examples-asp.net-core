﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MYExample.Models;

namespace MYExample.Controllers
{
    public class ProductController : Controller
    {
        public string Index()
        {
            return ("hi from product controller");
        }
        public ActionResult result()
        {
            Product product = new Product();
            product.Id = 12;
            product.Name = "ahmed jamal";
            product.Desciption = "welcome from midoo";
            string data = product.Id + product.Name + product.Desciption;
            return View("result",string.Format( "product ID:{0:c} ,product name :{1}",product.Id,product.Name));
        }

        public IActionResult autoCollection()
        {
            string[] stringArray = { "apple", "samsung" ,"nokia"};
            List<int> list = new List<int> { 10, 20, 30 };
            Dictionary<string, int> dic = new Dictionary<string, int>
            {
                {"apple",10 },{"samsung",20},{"nokia",30}
            };
            return View("result",list[1].ToString());
        }

        public IActionResult ExtentioMethod()
        {
            ShoppingCart cart = new ShoppingCart
            {
                products = new List<Product>
                {
                    new Product {Price=2},
                    new Product {Price=23},
                    new Product{Price=12}
                }
               
            };
            decimal total = cart.PriceTotal();
            return View("result", total.ToString());
        }
        public IActionResult ExtentionMethodIE()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                products = new List<Product>
                {
                    new Product {Price=2},
                    new Product {Price=23},
                    new Product{Price=12}
                }
            };
            Product[] productsArray =
             {
                    new Product {Price=2},
                    new Product {Price=23},
                    new Product{Price=12}
            };
            decimal totalPrice = products.PricetotalIE();
            decimal totalPriceArray = productsArray.PricetotalIE();

            return View("result",string.Format("Total Price IE{0:c},Total Price Array {1:c}",totalPrice,totalPriceArray).ToString());
        }

        public IActionResult FilterByCategory()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                products = new List<Product>
                {
                    new Product {Price=2,Category="apple"},
                    new Product {Price=23,Category="apple"},
                    new Product{Price=12,Category="samsung"}
                }
            };
            decimal total = 0;
            foreach (Product pro in products.FilterByCategory("apple"))
                 total += pro.Price;
            return View("result", string.Format("Total Price IE{0:c}", total ).ToString());

           // var ahmed = new {ahmed= "ahmed", ali=575,ayman= "midoo" };
        }

        public IActionResult CreateAnonArray()
        {
            var OddsAndEnds = new[]
            {
                new {Name="apple",Ctegory="company"},
                  new {Name="samsung",Ctegory="company"},
                    new {Name="red",Ctegory="color"},
                      new {Name="hondai",Ctegory="company Cars"},

            };
            StringBuilder stringBuildeRresult = new StringBuilder();
            foreach (var item in OddsAndEnds)
                stringBuildeRresult.Append(item.Name).Append("").Append("-");
            return View("result",stringBuildeRresult.ToString());
        }
    }
}