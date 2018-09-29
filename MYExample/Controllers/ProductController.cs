using System;
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
        public IActionResult FindProductByLINQ()
        {
            Product [] products=
             {
                new Product{Name="apple",Category="mobile phone",Price=202 },
                new Product{Name="nokia",Category="mobile phone",Price=328 },
                new Product{Name="samsung",Category="mobile phone",Price=697 },
                new Product{Name="blackbery",Category="mobile phone",Price=28 },
                new Product{Name="red",Category="colour",Price=128 }
            };
            var findCategory = from math in products
                               orderby math.Price ascending
                               select new { math.Name, math.Price, math.Category };
            int count = 0;
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var item in findCategory)
            {
                stringBuilder.AppendFormat("Price:{0}", item.Price);
                if (++count == 3)
                    break;
            }
            return View("result", stringBuilder.ToString());
        }

        public IActionResult FindProductByLINQ_Notation()
        {
            Product[] products =
             {
                new Product{Name="apple",Category="mobile phone",Price=202 },
                new Product{Name="nokia",Category="mobile phone",Price=328 },
                new Product{Name="samsung",Category="mobile phone",Price=697 },
                new Product{Name="blackbery",Category="mobile phone",Price=28 },
                new Product{Name="red",Category="colour",Price=128 }
            };

            // this .notion type in LINQ
            //this OrderByDescending  in   Deferred functions (Yes) in LINQ stystem

            var findCategory = products.OrderByDescending(p => p.Price)
                                           .Take(3)
                                           .Select(p => new { p.Name, p.Price, p.Category });
                                var sum1 =products.Sum(p => p.Price);
            //     .Where(p => p.Category == "mobile");


            products[2] = new Product
            {
                Name = "ahmed", Price = 55800
            };

            //this sum  in   Deferred functions (No) in LINQ stystem
            var sum2 = products.Sum(p => p.Price);

            // int count = 0;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in findCategory)
            {
                stringBuilder.AppendFormat("Price:{0}", item.Price);
                //if (++count == 3)
                //    break;
               
            }
            return View("result", string.Format("All result:{0},Sum1:{1},Sum2:{2}", stringBuilder.ToString(),sum1,sum2));
        }
    }
}