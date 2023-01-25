using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Data.Dto
{
    public class Category
    {
        [Required(ErrorMessage = "Product category is required")]
        public string Description { get; set; }
    }
}
