using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eProduct.Model
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        public int Qty { get; set; }
        public double Price { get; set; }

        public Guid ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
