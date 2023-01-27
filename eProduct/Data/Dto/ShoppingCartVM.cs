using api.eProduct.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Data.Dto
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
