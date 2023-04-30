using Gliese.Entities;
using Gliese.Entities.DTO;
using Gliese.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Interfaces.Repository
{
    public interface IWorkedTaskRepository : IBaseRepository<WorkedTask>
    {
        WorkedTask CreateWorkedTaskByDto(WorkedTaskDTO workedTaskDTO);
    }
}
