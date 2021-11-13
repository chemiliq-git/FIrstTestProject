using AutoMapper;
using CurrencyConversion.DTO;
using CurrencyConversion.Services;
using EventBus.Messages.Events;
using MassTransit;
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
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IMapper mapper;
        private readonly ILogger<CurrencyConversionController> logger;

        public CurrencyConversionController(
            ICurrencyConversionService currencyConversionService,
            IPublishEndpoint publishEndpoint,
            IMapper mapper,
            ILogger<CurrencyConversionController> logger)
        {
            this.currencyConversionService = currencyConversionService;
            this.publishEndpoint = publishEndpoint;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public CurrencyConversionResult CalculateCurrencyConversion(CurrencyConversionInput currencyConversionInput)
        {
            Task<CurrencyConversionResult> task = this.currencyConversionService.CalculateCurrencyConversionAsync(currencyConversionInput);
            task.Wait();

            return task.Result;
        }

        [HttpGet("CalculateCurrencyConversionMQ/", Name = "CalculateCurrencyConversionMQ")]
        public async Task<IActionResult> CalculateCurrencyConversionMQ(CurrencyConversionInput currencyConversionInput)
        {
            // send currency exchange event to rabbitmq
            var eventMessage = this.mapper.Map<CurrencyExchangeEvent>(currencyConversionInput);
            await this.publishEndpoint.Publish<CurrencyExchangeEvent>(eventMessage);

            string messages =  "Your request is accepted!!";
            return this.Ok(messages);
        }
    }
}
