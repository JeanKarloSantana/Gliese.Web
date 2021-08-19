using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities.ApiDTO
{
    public class EURCurrencyRateDTO
    {
        public bool Success { get; set; }
        public decimal Timestamp { get; set; }
        public string Base { get; set; }
        public DateTime Date { get; set; }        
        public EurRateDTO Rates { get; set; }
    }
}
