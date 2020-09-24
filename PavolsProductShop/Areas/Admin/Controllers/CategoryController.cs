using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcomCandyShop.Models;

namespace EcomCandyShop.Area.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private ShopContext context;
              
        public CategoryController(ShopContext ctx)
        {
            context = ctx;
           
        }

        public IActionResult Index()
        {
           
            return View();
        }
        [Route("[area]/Category/{id?}")]
        public IActionResult List()
        {
            var categories = context.Categories.OrderBy(c => c.CategoryID).ToList();
            return View(categories);

        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddUpdate", new Category());

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            var category = context.Categories.Find(id);
            return View("AddUpdate", category);

        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryID == 0)  // category does not exist create a new one 
                {
                    context.Categories.Add(category);
                }
                else // it does exist just update the record 
                {
                    context.Categories.Update(category);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Category");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate");
            }
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
           var category = context.Categories.Find(id);
           return View(category);
         

        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
           
            
                context.Categories.Remove(category);
                context.SaveChanges();
                return RedirectToAction("List", "Category");
           
        }

    }
}
