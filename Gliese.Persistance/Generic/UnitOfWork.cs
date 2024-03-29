﻿using Gliese.DAL.SQL;
using Gliese.Interfaces.Generic;
using Gliese.Interfaces.Repository;
using Gliese.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Persistance.Generic
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DeimosDbContext _dbContext;

        public UnitOfWork(DeimosDbContext dbContext)
        {
            _dbContext = dbContext;

            Currencies = new CurrencyRepository(_dbContext);
            ExchangeRates = new ExchangeRateRepository(_dbContext);            
            Person = new PersonRepository(_dbContext);            
            User = new UserRepository(_dbContext);            
            Account = new AccountRepository(_dbContext);
            WorkedTask = new WorkedTaskRepository(_dbContext);
        }

        public int Complete() => _dbContext.SaveChanges();
        public void Dispose() => _dbContext.Dispose();

        public ICurrencyRepository Currencies { get; set; }
        public IExchangeRateRepository ExchangeRates { get; set; }        
        public IPersonRepository Person { get; set; }
        public IUserRepository User { get; set; }
        public IAccountRepository Account { get; set; }
        public IWorkedTaskRepository WorkedTask { get; set; }
    }
}
