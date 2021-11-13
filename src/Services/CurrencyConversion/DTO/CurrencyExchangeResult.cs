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

        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }

        public decimal ConversionMultiple { get; set; }

        public decimal Quantity { get; set; }

        [JsonIgnore]
        public string ErrorMessage { get; set; }
    }
}
