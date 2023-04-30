
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Gliese.Entities
{
    public class User : IdentityUser<int>
    { 
        public DateTime DateCreated { get; set; }
        public Person Person { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<Account> Account { get; set; }
        public ICollection<WorkedTask> WorkedTask { get; set; }
    }
}
