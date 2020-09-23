﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PavolsProductShop.Models;

namespace PavolsProductShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ShopContext context;
        private List<Category> categories;


        public ProductController(ShopContext ctx)
        {
            context = ctx;
            categories = context.Categories.OrderBy(c => c.CategoryID).ToList();
        }
        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }
        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Product> products;

            if (id == "All")
            {
                products = context.Products.OrderBy(p => p.ProductID).ToList();
            }
            else
            {
                products = context.Products.Where(p => p.Category.Name == id).ToList();
            }
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            return ViewBag(products);

        }

        [HttpGet]
        public IActionResult Add()
        {
            var product = new Product();
            product.Category = context.Categories.Find(1);
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;
            return View("AddUpdate", product);
        }

        [HttpGet]
        public IActionResult Update (int id)
        {
            var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductID == id);
            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            return View("AddUpdate", product);
        }
        [HttpPost]
        public IActionResult Update (Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0) // add 
                {
                    context.Products.Add(product);
                }
                else // update 
                {
                    context.Products.Update(product);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductID == id);
            return ViewBag(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List", "Product");
        }

    }
}
