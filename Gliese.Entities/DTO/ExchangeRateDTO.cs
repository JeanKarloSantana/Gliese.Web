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
        public List<RatesDTO> Rates { get; set; }
    }
}
