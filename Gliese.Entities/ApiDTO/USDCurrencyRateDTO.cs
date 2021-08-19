using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities.ApiDTO
{
    public class USDCurrencyRateDTO
    {  
        public decimal Timestamp { get; set; }
        public string Base { get; set; }        
        public UsdRateDTO Rates { get; set; }        
    }
}
