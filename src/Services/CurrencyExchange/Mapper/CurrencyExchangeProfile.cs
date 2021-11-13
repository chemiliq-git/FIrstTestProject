using AutoMapper;
using CurrencyExchange.Commands;
using CurrencyExchange.DTO;
using EventBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Mapper
{
    public class CurrencyExchangeProfile : Profile
	{
		public CurrencyExchangeProfile()
		{
			CreateMap<CurrencyExchangeInput, CurrencyExchangeCommand>().ReverseMap();
			CreateMap<CurrencyExchangeEvent, CurrencyExchangeCommand>().ReverseMap();
			CreateMap<CurrencyExchangeResult, CurrencyConversionEvent>().ReverseMap();
		}
	}
}