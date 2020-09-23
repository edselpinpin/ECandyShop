using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace PavolsProductShop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                  new Category { CategoryID = 1, Name = "Chocolates" },
                  new Category { CategoryID = 2, Name = "Fruit Candy" },
                  new Category { CategoryID = 3, Name = "Haloween Candy" },
                  new Category { CategoryID = 4, Name = "Hard Candy" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    CategoryID = 2,
                    Code = "Gummy_Traditional",
                    Name = "Gummy Traditional Gummy Candy",
                    Price = (decimal)3.90

                },

                new Product
                {
                    ProductID = 2,
                    CategoryID = 2,
                    Code = "Gummy_Sour",
                    Name = "Gummy Sour Candy",
                    Price = (decimal)1.90

                },

                 new Product
                 {
                     ProductID = 3,
                     CategoryID = 3,
                     Code = "Halloween_Orange",
                     Name = "Halloween Orange Cones",
                     Price = (decimal)2.90

                 }
                );
        }

    }
}
