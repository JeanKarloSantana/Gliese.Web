﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities
{
    public class WorkedTask
    {
        public int Id { get; set; }
        public int IdUser { get; set; }        
        [Required] 
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required] 
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public User User { get; set; }
    }
}
