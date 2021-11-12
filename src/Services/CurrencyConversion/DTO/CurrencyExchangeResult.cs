using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyConversion.DTO
{
    public class CurrencyExchangeResult
    {
        public string id { get; set; }

        public bool? IsValidConversion { get; set; }

        public string fromCurrency { get; set; }

        public string toCurrency { get; set; }

        public decimal conversionMultiple { get; set; }

        [JsonIgnore]
        public string ErrorMessage { get; set; }
    }
}
