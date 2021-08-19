using Gliese.Entities.ApiDTO;
using Gliese.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Interfaces.Domain
{
    public interface IExchangeRateManager
    {
        Task<ResponseDTO<ExchangeRateDTO>> GetExchangeRateHandler(string code);
        Task<IActionResult> ReturnCurrencyClass(string code, ResponseDTO<ExchangeRateDTO> response);
    }
}
