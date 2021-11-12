using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversion.DTO
{
    public class CurrencyExchangeInput
    {
        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }
    }
}
