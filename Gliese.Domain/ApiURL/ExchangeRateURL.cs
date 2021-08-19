using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Domain.ApiURL
{
    public class ExchangeRateURL
    {
        public string EURCurrencyRate { get; set; } = "http://api.exchangeratesapi.io/v1/latest?access_key=d46a9cc58498538acf22c721d3229fa2&symbols=USD,AUD,CAD,PLN,MXN&format=1";
        public string USDCurrencyRate { get; set; } = "https://openexchangerates.org/api/latest.json?app_id=2ba557bdc0f346a0994c84443d1d6508";
        public string CADCurrencyRate { get; set; } = "https://exchange-rates.abstractapi.com/v1/live/?api_key=38ffa45304404b5ea0ccc9247fece7ea&base=CAD";
    }
}
