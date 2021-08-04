using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities
{
    public class Role : IdentityRole<int>
    {
        public DateTime DateCreated { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
