using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversion.DTO
{
    public class CurrencyConversionResult
    {
        public string Id { get; set; }
        public bool? IsValidConversion { get; set; }
        public string ErrorMessage { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal ConversionMultiple { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalCalculateAmount { get; set; }
    }
}
