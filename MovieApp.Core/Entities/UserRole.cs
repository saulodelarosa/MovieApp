using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class UserRole
    {
        public User UserId { get; set; }

        public Role RoleId { get; set; }
    }
}
