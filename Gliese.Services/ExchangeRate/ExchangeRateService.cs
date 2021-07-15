using Gliese.Domain.ApiURL;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Services.ExchangeRate
{
    public class ExchangeRateService
    {
        private readonly ExchangeRateURL _apiUrl;

        public void GetEURRates()
        {

        }

        private IRestResponse GetApiResponse(string url)
        {
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            IRestResponse requestResponse = client.Execute(request);

            return requestResponse;
        }
    }
}

