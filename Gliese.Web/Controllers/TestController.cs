using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gliese.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Route("Test")]
        [HttpGet]
        public IActionResult Test() 
        {
            try
            {
                return StatusCode(200, "Complete");
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }
    }
}
