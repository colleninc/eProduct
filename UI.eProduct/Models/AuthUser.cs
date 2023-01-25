using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.eProduct.Models
{
    public class AuthUser
    {
        public Guid UserId { get; set; }
        
        public string UserRole { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
