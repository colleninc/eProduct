using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.eProduct.Models;

namespace UI.eProduct.Data.VM
{
    public class ProductCategoryLK
    {
        public ProductCategoryLK()
        {
            Categories = new List<ProductCategory>();
        }
        public List<ProductCategory> Categories { get; set; }
    }
}
