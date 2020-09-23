using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PavolsProductShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter product price")]
        [Column(TypeName = "Decimal(18,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Product category is required")]
        public int CategoryID { get; set; } // Fforeign key 
        public Category Category { get; set; } //  constructor 
        [Required(ErrorMessage = "Please enter product code")]
        public string Code { get; set; }


        public decimal DiscountPercent => .20M;
        public decimal DiscoutAmount => Price * DiscountPercent;
        public decimal DiscountPrice => Price - DiscoutAmount;
        public string Slug => Name == null ? "" : Name.Replace(' ', '-');
        

    }
}
