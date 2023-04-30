using Gliese.DAL.SQL;
using Gliese.Entities;
using Gliese.Entities.DTO;
using Gliese.Interfaces.Repository;
using Gliese.Persistance.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Persistance.Repository
{
    public class WorkedTaskRepository : BaseRepository<WorkedTask>, IWorkedTaskRepository
    {
        public DeimosDbContext _context { get { return context; } }
        public WorkedTaskRepository(DeimosDbContext dbContext) : base(dbContext)
        {
        }

        public WorkedTask CreateWorkedTaskByDto(WorkedTaskDTO workedTaskDTO) => 
            new WorkedTask
            {
                IdUser = workedTaskDTO.IdUser,
                Description = workedTaskDTO.Description,
                StartTime = workedTaskDTO.StartTime,
                EndTime = workedTaskDTO.EndTime,
                Date = workedTaskDTO.Date
            };
    }
}
