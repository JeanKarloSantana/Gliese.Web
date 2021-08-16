using Gliese.Domain.ApiURL;
using Gliese.Entities.DTO;
using Gliese.Interfaces.Domain;
using Gliese.Interfaces.Service;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Domain.ExchangeRateManager
{
    public class ExchangeRateManager : IExchangeRateManager
    {
        private readonly ExchangeRateURL _apiUrl;
        private readonly IExchangeRateService _exchangeService;
        public ExchangeRateManager(ExchangeRateURL apiUrl, IExchangeRateService exchangeService) 
        {
            _apiUrl = apiUrl;
            _exchangeService = exchangeService;
        }

        /*public ResponseDTO<ExchangeRateDTO> GetExchangeRate(string code) 
        {
            IRestResponse 
        }*/
    }
}
