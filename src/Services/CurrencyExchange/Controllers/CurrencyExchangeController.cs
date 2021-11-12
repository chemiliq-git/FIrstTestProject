using CurrencyExchange.DTO;
using CurrencyExchange.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyExchangeController : ControllerBase
    {
        private readonly ICurrencyExchangeService currencyExchangeService;
        private readonly ILogger<CurrencyExchangeController> logger;

        public CurrencyExchangeController(
            ICurrencyExchangeService currencyExchangeService,
            ILogger<CurrencyExchangeController> logger)
        {
            this.currencyExchangeService = currencyExchangeService;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<CurrencyExchangeResult> Get(CurrencyExchangeInput currencyExchangeInput)
        {
            return this.currencyExchangeService.GetCurrencyExchanges(currencyExchangeInput);
        }
    }
}