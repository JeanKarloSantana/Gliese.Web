using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities
{
    public class PurchaseTransaction
    {
        public int Id { get; set; }
        public int IdExchangeRate { get; set; }
        public decimal Amount { get; set; }
        public decimal PurchasedAmount { get; set; }        
        public decimal BuyRateLog { get; set; }
        public decimal SellRateLog { get; set; }
        public DateTime Date { get; set; }
        public ExchangeRate ExchangeRate { get; set; }
        public MainTransaction MainTransaction { get; set; }
    }
}
