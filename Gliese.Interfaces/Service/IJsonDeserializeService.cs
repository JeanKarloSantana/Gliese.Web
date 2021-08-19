using Gliese.Entities.ApiDTO;
using Gliese.Entities.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Interfaces.Service
{
    public interface IJsonDeserializeService
    {
        Task<ExchangeRateDTO> ExchangeRateDeserialize(string code, IRestResponse rates);
    }
}
