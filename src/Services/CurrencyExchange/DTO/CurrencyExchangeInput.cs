using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.DTO
{
    public class CurrencyExchangeInput
    {
        public string fromCurrency { get; set; }
     
        public string toCurrency { get; set; }
    }
}
