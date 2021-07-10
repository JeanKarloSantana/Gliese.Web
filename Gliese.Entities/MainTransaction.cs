using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities
{
    public class MainTransaction
    {
        public int Id { get; set; }        
        public int IdPerson { get; set; }
        public int IdTransactionType { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public TransactionType TransactionType { get; set; }        
    }
}
