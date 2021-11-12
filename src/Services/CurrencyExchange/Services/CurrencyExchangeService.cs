using CurrencyExchange.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        public CurrencyExchangeResult GetCurrencyExchanges(CurrencyExchangeInput inputData)
        {
            return
                new CurrencyExchangeResult()
                {
                    ID = "100",
                    IsValidConversion = true,
                    FromCurrency = "USD",
                    ToCurrency = "INR",
                    ConversionMultiple = 65,
                };
        }
    }
}
