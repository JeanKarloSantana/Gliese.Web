using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int AccNumber { get; set; }
        public int IdAccCurrency { get; set; }
        public int IdAccUser { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public DateTime Opened { get; set; }
        public DateTime Closed { get; set; }
        public Currency Currency { get; set; }
        public User User { get; set; }        
    }
}
