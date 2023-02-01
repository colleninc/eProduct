using eProduct.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Data.Dto
{
    public class NewProductLookupVM
    {
        public NewProductLookupVM()
        {
            Categories = new List<ProductCategory>();
        }
           
        public List<ProductCategory> Categories { get; set; }
    }
}
