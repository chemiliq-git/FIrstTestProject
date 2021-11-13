using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class CurrencyConversionEvent : IntegrationBaseEvent
    {
        public bool IsValidConversion { get; set; }

        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }

        public decimal ConversionMultiple { get; set; }

        public decimal Quantity { get; set; }
    }
}