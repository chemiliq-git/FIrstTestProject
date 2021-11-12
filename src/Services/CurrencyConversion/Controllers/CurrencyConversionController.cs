using CurrencyConversion.DTO;
using CurrencyConversion.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConversionController : ControllerBase
    {
        private readonly ICurrencyConversionService currencyConversionService;
        private readonly ILogger<CurrencyConversionController> _logger;

        public CurrencyConversionController(
            ICurrencyConversionService currencyConversionService,
            ILogger<CurrencyConversionController> logger)
        {
            this.currencyConversionService = currencyConversionService;
            _logger = logger;
        }

        [HttpGet]
        public CurrencyConversionResult CalculateCurrencyConversion(CurrencyConversionInput currencyConversionInput)
        {
            Task<CurrencyConversionResult> task = this.currencyConversionService.CalculateCurrencyConversionAsync(currencyConversionInput);
            task.Wait();

            return task.Result;
        }
    }
}
