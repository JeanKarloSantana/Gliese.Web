using Gliese.Entities.ApiDTO;
using Gliese.Entities.DTO;
using Gliese.Entities.Exceptions;
using Gliese.Interfaces.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gliese.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExchangeRateManager _exchangeRate;

        public ExchangeRateController(IExchangeRateManager exchangeRate) 
        {
            _exchangeRate = exchangeRate;
        }

        [Route("Get/{code}")]
        [HttpGet]
        public async Task<IActionResult> GetExchangeRate(string code) 
        {
            try
            {
                ResponseDTO<ExchangeRateDTO> response = await _exchangeRate.GetExchangeRateHandler(code);

                if (!response.Succeeded) return StatusCode(response.StatusCode, response.Errors);

                return await _exchangeRate.ReturnCurrencyClass(code, response);
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
