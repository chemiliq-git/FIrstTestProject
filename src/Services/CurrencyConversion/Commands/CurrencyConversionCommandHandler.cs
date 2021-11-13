using AutoMapper;
using CurrencyConversion.DTO;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace CurrencyConversion.Commands
{
    public class CurrencyConversionCommandHandler : IRequestHandler<CurrencyConversionCommand, CurrencyConversionResult>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IMapper mapper;

        public CurrencyConversionCommandHandler(
            IPublishEndpoint publishEndpoint,
            IMapper mapper)
        {
            this.publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CurrencyConversionResult> Handle(CurrencyConversionCommand request, CancellationToken cancellationToken)
        {
            var inputData = this.mapper.Map<CurrencyExchangeResult>(request);

            inputData.Quantity = inputData.Quantity * inputData.ConversionMultiple;
            return null;
        }
    }
}
