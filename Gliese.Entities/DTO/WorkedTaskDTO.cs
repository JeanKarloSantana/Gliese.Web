using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities.DTO
{
    public class WorkedTaskDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        
        public string StartTime { get; set; }
        
        public string EndTime { get; set; }
        
        public string Description { get; set; }
        
        public DateTime Date { get; set; }
    }
}
