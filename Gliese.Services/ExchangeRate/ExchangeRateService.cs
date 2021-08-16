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

namespace Gliese.Services.ExchangeRate
{
    public class ExchangeRateService : IExchangeRateService
    {
        public ExchangeRateDTO GetExchangeRate(string code) =>
            code switch
            {

            };
        

        private IRestResponse GetApiResponse(string url)
        {
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            IRestResponse requestResponse = client.Execute(request);

            return requestResponse;
        }
    }
}

