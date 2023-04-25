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
    public class ExchangeRateRepository : BaseRepository<ExchangeRate>, IExchangeRateRepository
    {
        public DeimosDbContext _context { get { return context; } }

        public ExchangeRateRepository(DeimosDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<List<ExchangeRate>> GetCurrencyAllExchangeRate(int id) => await context.ExchangeRate
            .Where(r => r.IdFromCurrency == id)
            .ToListAsync();        
    }
}
