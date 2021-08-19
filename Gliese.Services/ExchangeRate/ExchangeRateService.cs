using Gliese.Domain.ApiURL;
using Gliese.Entities.ApiDTO;
using Gliese.Entities.DTO;
using Gliese.Entities.Enums;
using Gliese.Entities.Exceptions;
using Gliese.Entities.Messages;
using Gliese.Interfaces.Domain;
using Gliese.Interfaces.Service;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Services.ExchangeRate
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly ExchangeRateURL _apiUrl;
        private readonly ErrorMessages _errorMessages;

        public ExchangeRateService(ExchangeRateURL apiUrl, ErrorMessages errorMessages)
        {
            _apiUrl = apiUrl;
            _errorMessages = errorMessages;
        }

        public async Task<IRestResponse> GetExchangeRate(string code) =>
            code switch
            {
                "USD" => await GetApiResponse(_apiUrl.USDCurrencyRate),
                "EUR" => await GetApiResponse(_apiUrl.EURCurrencyRate),
                "CAD" => await GetApiResponse(_apiUrl.CADCurrencyRate),
                _ => throw new ArgumentExceptionEx(message: _errorMessages.InvalidCurrencyCode, paramName: nameof(code))
            };

        private async Task<IRestResponse> GetApiResponse(string url)
        {
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            IRestResponse requestResponse = client.Execute(request);

            return await Task.FromResult(requestResponse);
        }        
    }
}

