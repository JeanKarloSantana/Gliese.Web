﻿using Gliese.Entities;
using Gliese.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Interfaces.Repository
{
    public interface ICurrencyRepository : IBaseRepository<Currency>
    {
        Task<int> GetIdCurrencyByCode(string code);
    }
}
