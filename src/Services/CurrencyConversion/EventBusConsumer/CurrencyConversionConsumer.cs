using AutoMapper;
using CurrencyConversion.Commands;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CurrencyConversion.EventBusConsumer
{
    public class CurrencyConversionConsumer : IConsumer<CurrencyConversionEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CurrencyConversionConsumer> _logger;

        public CurrencyConversionConsumer(IMediator mediator, IMapper mapper, ILogger<CurrencyConversionConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        async Task IConsumer<CurrencyConversionEvent>.Consume(ConsumeContext<CurrencyConversionEvent> context)
        {
            var command = _mapper.Map<CurrencyConversionCommand>(context.Message);
            var result = await _mediator.Send(command);
        }
    }
}
