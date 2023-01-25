using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProduct.Data.Dto
{
    public class ProductDto
    {
        public Guid ProductCategoryID { get; set; }
        public int Re_OrderLevel { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }
}
