using Gliese.Entities.ApiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities.DTO
{
    public class ExchangeRateDTO
    {
        public string Base { get; set; }
        public List<RatesDTO> ListRates { get; set; }        
        public EURCurrencyRateDTO EURCurrencyRate { get; set; }
        public USDCurrencyRateDTO USDCurrencyRate { get; set; }
        public CADCurrencyRateDTO CADCurrencyRate { get; set; }
    }
}
