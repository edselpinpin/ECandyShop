using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomCandyShop.Models
{
    public class ProductListViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public string SelectedCategory { get; set; }

        // methods 
        public string CheckActiveCategory(string category) => category == SelectedCategory ? "active" : "";
    }
}
