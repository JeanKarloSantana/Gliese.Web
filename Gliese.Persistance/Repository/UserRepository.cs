using Gliese.DAL.SQL;
using Gliese.Entities;
using Gliese.Interfaces.Repository;
using Gliese.Persistance.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Persistance.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public DeimosDbContext _context { get { return context; } }

        public UserRepository(DeimosDbContext dbContext) : base(dbContext)
        {
        }

        /*public async Task<User> GetUserByUsername(string username) => await context.User
            .Where(x => x == username)
            .FirstOrDefaultAsync();*/
    }
}
