using eProduct.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Model
{
    public class ShoppingCartItem
    {
        [Key]
        public Guid Id { get; set; }

        public Product Product { get; set; }
        public int Quantity { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
