using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Domain.Business
{
    public class PurchaseTransactionLimits
    {
        public bool purchaseCurrencyLimitCAD(decimal amount) => amount <= 50000;
        public bool purchaseCurrencyLimitDOP(decimal amount) => amount <= 100000;
        public bool purchaseCurrencyLimitBRL(decimal amount) => amount <= 35000;
        public bool purchaseCurrencyLimitEUR(decimal amount) => amount <= 120000;     
        public bool purchaseCurrencyLimitBTC(decimal amount) => amount <= 115000;
        public bool purchaseCurrencyLimitOthers(decimal amount) => amount <= 30000;
    }    
}
