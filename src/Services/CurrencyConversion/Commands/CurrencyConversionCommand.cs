using CurrencyConversion.DTO;
using MediatR;

namespace CurrencyConversion.Commands
{
    public class CurrencyConversionCommand : IRequest<CurrencyConversionResult>
    {
        public bool IsValidConversion { get; set; }

        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }

        public decimal ConversionMultiple { get; set; }

        public decimal Quantity { get; set; }
    }
}