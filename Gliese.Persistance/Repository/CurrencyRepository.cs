using Gliese.DAL.SQL;
using Gliese.Entities;
using Gliese.Entities.DTO;
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
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository 
    {
        public DeimosDbContext _context { get { return context; } }

        public CurrencyRepository(DeimosDbContext dbContext) : base(dbContext)
        {           
        }

        public async Task<int> GetIdCurrencyByCode(string code) => await context.Currency
            .Where(currency => currency.Code == code)
            .Select(currency => currency.Id)
            .FirstOrDefaultAsync();
    }
}
