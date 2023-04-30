using Gliese.Entities;
using Gliese.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Interfaces.Domain
{
    public interface IWorkedTaskManager 
    {
        Task<IActionResult> AddWorkedTask(WorkedTaskDTO workedTask);
    }
}
