using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string ISOCode { get; set; }
        [Required]
        public string Name { get; set; }
        public int IdCurrency { get; set; }
        public Currency Currency { get; set; }
    }
}
