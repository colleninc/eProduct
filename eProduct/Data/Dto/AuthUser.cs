using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Data.Dto
{
    public class AuthUser
    {
        public Guid UserId { get; set; }
        //public string RoleId { get; set; }
        public string UserRole { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        //public string Cellphone { get; set; }
    }
}
