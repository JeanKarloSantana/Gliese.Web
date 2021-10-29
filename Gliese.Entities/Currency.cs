using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }        
        [Required]
        public string Name { get; set; }
        public ICollection<ExchangeRate> ExchangeRatesFrom { get; set; }
        public ICollection<ExchangeRate> ExchangeRatesTo { get; set; }
        public ICollection<Country> Country { get; set; }
        public ICollection<Account> Account { get; set; }
    }
}
