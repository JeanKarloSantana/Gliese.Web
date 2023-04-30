using Gliese.Domain.themis;
using Gliese.Entities;
using Gliese.Entities.DTO;
using Gliese.Interfaces.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Gliese.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkedTaskController : ControllerBase
    {
        private readonly IWorkedTaskManager _workedTaskManager;
        public WorkedTaskController(IWorkedTaskManager workTaskManager) 
        {
            _workedTaskManager = workTaskManager;
        }

        [HttpPost]
        [Route("AddWorkedTask")]
        public async Task<IActionResult> AddWorkedTask([FromBody] WorkedTaskDTO dto)
        {
            try
            {
                IActionResult response = await _workedTaskManager.AddWorkedTask(dto);
                return response;
            }
            catch (Exception ex)
            {
                return await ReturnThrowException(ex.GetType(), ex);
            }
        }

        private async Task<IActionResult> ReturnThrowException(Type exType, Exception ex) =>
           exType.Name switch
           {
               "ArgumentExceptionEx" => await Task.FromResult(StatusCode(400, ex.Message)),
               _ => await Task.FromResult(StatusCode(500, ex.Message))
           };
    }
}
