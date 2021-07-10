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
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository 
    {
        public GlieseDbContext _context { get { return context; } }

        public CurrencyRepository(GlieseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
