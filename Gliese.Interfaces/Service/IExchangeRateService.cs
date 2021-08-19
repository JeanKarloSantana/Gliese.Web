using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Interfaces.Service
{
    public interface IExchangeRateService
    {
        Task<IRestResponse> GetExchangeRate(string code);
    }
}
