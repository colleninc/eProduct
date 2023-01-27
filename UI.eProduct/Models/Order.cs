using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace UI.eProduct.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }       
        public DateTimeOffset OrderDate { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AuthUser User { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
