using Gliese.Entities;
using Gliese.Entities.ApiDTO;
using Gliese.Entities.DTO;
using Gliese.Entities.Exceptions;
using Gliese.Interfaces.Domain;
using Gliese.Interfaces.Generic;
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
        private readonly IUnitOfWork _unitOfWork;

        public ExchangeRateController(
            IExchangeRateManager exchangeRate, 
            IUnitOfWork unitOfWork
            ) 
        {
            _exchangeRate = exchangeRate;
            _unitOfWork = unitOfWork;
        }

        [Route("Get/{code}")]
        [HttpGet]
        public async Task<IActionResult> GetExchangeRate(string code) 
        {
            try
            {
                ResponseDTO<ExchangeRateDTO> response = await _exchangeRate.GetExchangeRateHandler(code);

                if (!response.succeed) return StatusCode(response.StatusCode, response.Errors);

                return await _exchangeRate.ReturnCurrencyClass(code, response);
            }
            catch (Exception ex) 
            {
                return await ReturnThrowException(ex.GetType(), ex);             
            }                           
        }

        [Route("Get/Test")]
        [HttpGet]
        public string GetMsg()
        {
            try
            { 

                return "Test was successful";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [Route("GetOneCurrencyAllRates/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetCurrencyRate(int id)
        {
            try
            {                
                return StatusCode(200, await _unitOfWork.ExchangeRates.GetCurrencyAllExchangeRate(id));
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
