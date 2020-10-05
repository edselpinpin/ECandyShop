using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using EcomCandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Microsoft.IdentityModel.Tokens;

namespace EcomCandyShop.Controllers
{
    public class CartController : Controller
    {
        private ShopContext context;
        // private List<Basket> basket;


        public CartController(ShopContext ctx)
        {
            context = ctx;
            // basket = context.Basket.OrderBy(b => b.ProductID).ToList();

        }


        public IActionResult index()
        {
            var model = (from b in context.Basket
                         join
                         p in context.Products on
                         b.ProductID equals p.ProductID
                         select new BasketListViewModel()
                         {
                             BasketId = b.BasketId,
                             ProductId = p.ProductID,
                             ProductName = p.Name,
                             Price = p.Price,
                             Quantity = b.Quantity
                         }
                        ).ToList();

            return View(model);
        }

        public IActionResult Add(int id)
        {
            Product product = context.Products.Find(id);
            var basket = context.Basket.FirstOrDefault(b => b.ProductID == id);

            if (basket == null)
            {
                basket = new Basket()
                {
                    ProductID = product.ProductID,
                    Quantity = 1

                };
                context.Basket.Add(basket);

            }
            else
            {
                basket.Quantity = basket.Quantity + 1;
                context.Basket.Update(basket);
            }

            context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete (int id)
        {
            var basket = context.Basket.FirstOrDefault(b => b.BasketId == id);
            
                return View(basket);
        }
        [HttpPost]
        public IActionResult Delete(Basket basket)

        {         
            
            context.Basket.Remove(basket);
            
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
