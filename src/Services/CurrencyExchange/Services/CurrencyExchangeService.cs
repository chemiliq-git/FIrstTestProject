using CurrencyExchange.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        public IEnumerable<CurrencyExchangeResult> GetCurrencyExchanges(CurrencyExchangeInput inputData)
        {
            return new List<CurrencyExchangeResult>() {
                new CurrencyExchangeResult()
                {
                    ID = "100",
                    IsValidConversion = true,
                    FromCurrency ="USD",
                    ToCurrency = "INR",
                    ConversionMultiple = 65,
                }
            };
        }
    }
}
