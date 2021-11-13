using AutoMapper;
using CurrencyExchange.DTO;
using CurrencyExchange.Services;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyExchange.Commands
{
    public class CurrencyExchangeCommandHandler : IRequestHandler<CurrencyExchangeCommand, CurrencyExchangeResult>
    {
        private readonly ICurrencyExchangeService currencyExchangeService;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IMapper mapper;

        public CurrencyExchangeCommandHandler(
            ICurrencyExchangeService currencyExchangeService,
            IPublishEndpoint publishEndpoint,
            IMapper mapper)
        {
            this.currencyExchangeService = currencyExchangeService ?? throw new ArgumentNullException(nameof(currencyExchangeService));
            this.publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CurrencyExchangeResult> Handle(CurrencyExchangeCommand request, CancellationToken cancellationToken)
        {
            var inputData = this.mapper.Map<CurrencyExchangeInput>(request);

            CurrencyExchangeResult result = await Task.Run(() => this.currencyExchangeService.GetCurrencyExchanges(inputData));

            try
            {
                // send currency exchange event to rabbitmq
                var eventMessage = this.mapper.Map<CurrencyConversionEvent>(result);
                await this.publishEndpoint.Publish<CurrencyConversionEvent>(eventMessage);
            }
            catch(Exception e)
            {

            }

            return result;
        }
    }
}
