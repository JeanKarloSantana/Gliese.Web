using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities
{
    public class TransactionType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int Active { get; set; }
        public ICollection<MainTransaction> MainTransaction { get; set; }
    }
}
