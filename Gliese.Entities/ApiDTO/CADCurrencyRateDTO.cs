using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities.ApiDTO
{
    public class CADCurrencyRateDTO
    {
        public string Base { get; set; }
        public decimal Last_Updated  { get; set; }
        public CadRateDTO Exchange_Rates { get; set; }
    }
}
