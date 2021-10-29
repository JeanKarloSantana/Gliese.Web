using Gliese.Domain.ApiURL;
using Gliese.Entities.DTO;
using Gliese.Entities.Messages;
using Gliese.Interfaces.Domain;
using Gliese.Interfaces.Service;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Dynamic;
using Gliese.Entities.ApiDTO;
using Gliese.Entities.Enums;
using Gliese.Interfaces.Generic;
using Microsoft.AspNetCore.Mvc;
using Gliese.Entities;

namespace Gliese.Domain.ExchangeRateManager
{
    public class ExchangeRateManager : IExchangeRateManager
    {
        private readonly IExchangeRateService _exchangeService;
        private readonly IJsonDeserializeService _jsonDeserialize;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ErrorMessages _errorMessages;
        public ExchangeRateManager
        (
            IExchangeRateService exchangeService,
            IJsonDeserializeService jsonDeserialize,
            IUnitOfWork unitOfWork
        )
        {
            _exchangeService = exchangeService;
            _jsonDeserialize = jsonDeserialize;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO<ExchangeRateDTO>> GetExchangeRateHandler(string code)
        {
            var response = new ResponseDTO<ExchangeRateDTO>();

            IRestResponse rates = await _exchangeService.GetExchangeRate(code);

            if (!rates.IsSuccessful) return await UnableToRetrieveApiData(response);

            response.Data = await _jsonDeserialize.ExchangeRateDeserialize(code, rates);

            return response;
        }

        private async Task<ResponseDTO<ExchangeRateDTO>> UnableToRetrieveApiData(ResponseDTO<ExchangeRateDTO> response)
        {
            response.Errors.Add(_errorMessages.UnableToRetrieveApiData);
            response.Succeeded = false;
            response.StatusCode = 500;
            return await Task.FromResult(response);
        }

        public async Task<IActionResult> ReturnCurrencyClass(string code, ResponseDTO<ExchangeRateDTO> response) => code switch
        {
            "USD" => await Task.FromResult(new ObjectResult(response.Data.USDCurrencyRate) { StatusCode = 200 }),
            "EUR" => await Task.FromResult(new ObjectResult(response.Data.EURCurrencyRate) { StatusCode = 200 }),
            "CAD" => await Task.FromResult(new ObjectResult(response.Data.CADCurrencyRate) { StatusCode = 200 }),
            _ => throw new ArgumentException(message: _errorMessages.InvalidCurrencyCode, paramName: nameof(code)),
        };                  
    }
}
