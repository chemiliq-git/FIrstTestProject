using CurrencyConversion.DTO;
using CurrencyConversion.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversion.Services
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<CurrencyConversionService> logger;

        private CurrencyExchangeAPIClient apiClient;

        public CurrencyConversionService(
            IConfiguration configuration,
            ILogger<CurrencyConversionService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<CurrencyConversionResult> CalculateCurrencyConversionAsync(CurrencyConversionInput inputData)
        {
            CurrencyExchangeInput requetData = new CurrencyExchangeInput()
            {
                FromCurrency = inputData.FromCurrency,
                ToCurrency = inputData.ToCurrency,
            };

            string address = configuration.GetValue<string>("CurrencyExchangeServerAddress");
            this.apiClient = new CurrencyExchangeAPIClient(address);
            CurrencyExchangeResult result = await this.apiClient.InvokeCurrencyExchangeAPIAsync(requetData);

            if (result.IsValidConversion.HasValue
                && result.IsValidConversion.Value)
            {
                return new CurrencyConversionResult()
                {
                    Id = result.id,
                    IsValidConversion = true,
                    ConversionMultiple = result.ConversionMultiple,
                    FromCurrency = result.FromCurrency,
                    ToCurrency = result.ToCurrency,
                    Quantity = inputData.Quantity,
                    TotalCalculateAmount = inputData.Quantity * result.ConversionMultiple,
                };
            }
            else
            {
                return new CurrencyConversionResult()
                {
                    IsValidConversion = result.IsValidConversion,
                    ErrorMessage = result.ErrorMessage,
                };
            }

        }

        public Task<CurrencyConversionResult> CalculateCurrencyConversionMQAsync(CurrencyConversionInput inputData)
        {
            return null;
        }
    }
}
