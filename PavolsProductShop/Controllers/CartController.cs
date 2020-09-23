﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PavolsProductShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(string Id)
        {
          
            ViewBag.ProductSlug = Id;
            return View();
        }
    }
}
