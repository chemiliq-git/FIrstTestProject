using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class CurrencyExchangeEvent : IntegrationBaseEvent
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Quantity { get; set; }
    }
}
