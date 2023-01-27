using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.eProduct.Models
{
    public class ProductCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
