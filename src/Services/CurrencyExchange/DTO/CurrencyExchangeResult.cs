using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.DTO
{
    public class CurrencyExchangeResult
    {
        public string ID { get; set; }

        public bool IsValidConversion { get; set; }

        public string FromCurrency { get; set; }
     
        public string ToCurrency { get; set; }
        
        public decimal ConversionMultiple { get; set; }

    }
}
