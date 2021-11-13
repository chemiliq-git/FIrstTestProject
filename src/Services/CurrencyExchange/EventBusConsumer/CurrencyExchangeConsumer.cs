using AutoMapper;
using CurrencyExchange.Commands;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CurrencyExchange.EventBusConsumer
{
    public class CurrencyExchangeConsumer : IConsumer<CurrencyExchangeEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CurrencyExchangeConsumer> _logger;

        public CurrencyExchangeConsumer(IMediator mediator, IMapper mapper, ILogger<CurrencyExchangeConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        async Task IConsumer<CurrencyExchangeEvent>.Consume(ConsumeContext<CurrencyExchangeEvent> context)
        {
            var command = _mapper.Map<CurrencyExchangeCommand>(context.Message);
            await _mediator.Send(command);
        }
    }
}
