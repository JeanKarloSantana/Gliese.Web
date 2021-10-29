using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public int IdFromCurrency { get; set; }
        public int IdToCurrency { get; set; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        public DateTime Updated { get; set; }
        public Currency CurrencyFrom { get; set; }
        public Currency CurrencyTo { get; set; }        
        public ICollection<PurchaseTransaction> PurchaseTransaction { get; set; }        
    }
}
