using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PavolsProductShop.Models;


namespace PavolsProductShop.Controllers
{
    public class ProductController : Controller
    {
        
        private ShopContext context;

        public ProductController(ShopContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index ()
        {
            return  RedirectToAction("List", "Products");
        }
           
     
        public IActionResult Detail(int id)
        {
            var categories = context.Categories.OrderBy(c => c.CategoryID).ToList();

            Product product = context.Products.Find(id);

            var CategoryName = "";
            foreach(var category in categories)
            {
                if (category.CategoryID == product.ProductID)
                {
                    CategoryName = category.Name;
                }
            }

                string imageFileName = product.Code + "-m.jpg";
                ViewBag.ImageFileName = imageFileName;
                ViewBag.Categories   = categories;
                ViewBag.CategoryName = CategoryName;
               
                return View(product);


         
            // Product product = Database.GetProduct(slugLink*/);
            // return View();
        }
        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All") // Id is the name tof the catagory used in the filtering 
        {
            var categories = context.Categories.OrderBy(c => c.CategoryID).ToList();
            List<Product> products;

            if (id == "All")
            {
                products = context.Products.OrderBy(prod => prod.ProductID).ToList();
            }
            else
                products = context.Products.Where(p => p.Category.Name == id).OrderBy(p => p.ProductID).ToList();

            ViewBag.SelectedCategoryName = id;
            ViewBag.AllCategories = categories;

            return View(products);

        }
    }
}
