using eProduct.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProduct.Model
{
    public class Product : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(ProductCategoryId))]
        public Guid ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int Re_OrderLevel { get; set; }
        public int Quantity { get; set; }
        public string ProductName{ get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
