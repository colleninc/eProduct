using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Data.Dto
{
    public class OrderDto
    {
        public string CartId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
    }
}
