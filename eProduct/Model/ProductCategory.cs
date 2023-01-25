using eProduct.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProduct.Model
{
    public class ProductCategory : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
