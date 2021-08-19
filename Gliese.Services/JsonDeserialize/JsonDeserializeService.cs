using Gliese.Entities.ApiDTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gliese.Interfaces.Service;
using Gliese.Entities.DTO;
using Gliese.Entities.Enums;
using Gliese.Entities.Exceptions;
using Gliese.Entities.Messages;

namespace Gliese.Services.JsonDeserialize
{
    public class JsonDeserializeService : IJsonDeserializeService
    {
        private readonly ErrorMessages _errorMessages;
        public JsonDeserializeService(ErrorMessages errorMessages) 
        {
            _errorMessages = errorMessages;
        }

        public async Task<ExchangeRateDTO> ExchangeRateDeserialize(string code, IRestResponse rates) =>
           code switch
            {
                "USD" => await USDCurrencyRateDeserialize(rates),
                "EUR" => await EURCurrencyRateDeserialize(rates),
                "CAD" => await CADCurrencyRateDeserialize(rates),
                _ => throw new ArgumentExceptionEx(message: _errorMessages.InvalidCurrencyCode, paramName: nameof(code))
            };

        public async Task<ExchangeRateDTO> EURCurrencyRateDeserialize(IRestResponse rates)
        {
            var eurRates = new ExchangeRateDTO { EURCurrencyRate = JsonConvert.DeserializeObject<EURCurrencyRateDTO>(rates.Content) };
            return await Task.FromResult(eurRates);
        }

        public async Task<ExchangeRateDTO> USDCurrencyRateDeserialize(IRestResponse rates)
        {
            var usdRates = new ExchangeRateDTO { USDCurrencyRate = JsonConvert.DeserializeObject<USDCurrencyRateDTO>(rates.Content) };
            return await Task.FromResult(usdRates);
        }

        public async Task<ExchangeRateDTO> CADCurrencyRateDeserialize(IRestResponse rates)
        {
            var cadRates = new ExchangeRateDTO { CADCurrencyRate = JsonConvert.DeserializeObject<CADCurrencyRateDTO>(rates.Content) };
            return await Task.FromResult(cadRates);
        }
    }
}
