using Gliese.Entities;
using Gliese.Entities.DTO;
using Gliese.Interfaces.Domain;
using Gliese.Interfaces.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Domain.themis
{
    public class WorkedTaskManager : IWorkedTaskManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkedTaskManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> AddWorkedTask(WorkedTaskDTO workTaskDto)
        {
            var response = new ResponseDTO<WorkedTask>();
            
            _unitOfWork.WorkedTask.Add(_unitOfWork.WorkedTask.CreateWorkedTaskByDto(workTaskDto));
            _unitOfWork.Complete();

            response.Message = "The entity was created successfully";

            return await Task.FromResult(new ObjectResult(response.Message) { StatusCode = 200 });
        }
    }
}
