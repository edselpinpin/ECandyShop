using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcomCandyShop.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        [Required]
        public int ProductID { get; set; }
        public int Quantity { get; set; }

    }
}
