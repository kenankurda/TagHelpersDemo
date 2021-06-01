using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TagHelpersDemo.Models;

namespace TagHelpersDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Product prod)
        {
           
            prod.BillAmount = prod.Cost * prod.Quantity;
            if (prod.BillAmount > 100 && prod.IsPartOfDeal)
            {
                prod.Discount = prod.BillAmount * 10 / 100;
            }
            else
            {
                prod.Discount = prod.BillAmount * 5 / 100;
            }

            ViewBag.BillAmount = prod.BillAmount;
            ViewBag.Discount = prod.Discount;
            

            prod.NetBillAmount = prod.BillAmount - prod.Discount;

            switch (prod.CategoryID)
            {
                case 1:
                case 2:
                    prod.NetBillAmount -= 10;
                    ViewBag.NetBillAmount = prod.NetBillAmount;
                    break;
                default:
                    break;
            }

            return View(prod);
        }
    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
