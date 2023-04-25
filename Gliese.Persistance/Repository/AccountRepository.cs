using Gliese.DAL.SQL;
using Gliese.Entities;
using Gliese.Interfaces.Repository;
using Gliese.Persistance.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Persistance.Repository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public DeimosDbContext _context { get { return context; } }

        public AccountRepository(DeimosDbContext dbContext) : base(dbContext)
        {
        }
    }
}
