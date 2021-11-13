using CurrencyExchange.DTO;
using MediatR;

namespace CurrencyExchange.Commands
{
    public class CurrencyExchangeCommand : IRequest<CurrencyExchangeResult>
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Quantity { get; set; }
    }
}
