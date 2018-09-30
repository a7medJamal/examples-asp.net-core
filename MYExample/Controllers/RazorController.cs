using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MYExample.Models;

namespace MYExample.Controllers
{
    public class RazorController : Controller
    {

        Product pro = new Product  
        {
           Id = 1, Name = "apple", Desciption = "smat phone", Price = 255 
       

        };
        public IActionResult Index()
        {

            return View(pro);
        }
        public IActionResult DemoArray()
        {
            Product[] pro =
            {
                new Product {  Id = 1, Name = "apple", Desciption = "smat phone", Price = 255},
                 new Product {  Id = 2, Name = "samsung", Desciption = "smat phone", Price = 200},
                  new Product {  Id = 3, Name = "nokia", Desciption = "smat phone", Price = 298},
                   new Product {  Id = 4, Name = "apple2", Desciption = "smat phone", Price = 2545},
                 new Product {  Id = 5, Name = "samsung2", Desciption = "smat phone", Price = 214},
                  new Product {  Id = 6, Name = "nokia2", Desciption = "smat phone", Price = 229}

            };
            return View(pro);
        }
    }
}