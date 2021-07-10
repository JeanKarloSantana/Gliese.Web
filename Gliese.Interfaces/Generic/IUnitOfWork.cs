using Gliese.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Interfaces.Generic
{
    public interface IUnitOfWork
    {
        int Complete();
        void Dispose();

        public ICurrencyRepository Currencies { get; set; }
        public IExchangeRateRepository ExchangeRates { get; set; }
        public IPersonRepository Person { get; set; }        
    }
}
