using CurrencyConversion.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversion.Services
{
    public interface ICurrencyConversionService
    {
        public Task<CurrencyConversionResult> CalculateCurrencyConversionAsync(CurrencyConversionInput inputData);

        public Task<CurrencyConversionResult> CalculateCurrencyConversionMQAsync(CurrencyConversionInput inputData);
    }
}
