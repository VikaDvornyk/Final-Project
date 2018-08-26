using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBLL.DTO
{
    public class UserDTO: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
        //public int Id { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string UserName { get; set; }
        //public int RoleId { get; set; }
        //public RoleDTO RoleDTO { get; set; }
    }
}
