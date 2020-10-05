using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace EcomCandyShop.Models
{
    public class BasketListViewModel
    {
        public int BasketId  { get; set; }
        public int  Quantity  { get; set; }
        public int  ProductId { get; set; }
        public string  ProductName  { get; set; }
        public decimal Price { get; set; }
    }
}
