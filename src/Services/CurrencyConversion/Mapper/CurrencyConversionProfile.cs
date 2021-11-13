using AutoMapper;
using CurrencyConversion.Commands;
using CurrencyConversion.DTO;
using EventBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversion.Mapper
{
    public class CurrencyConversionProfile : Profile
	{
		public CurrencyConversionProfile()
		{
			CreateMap<CurrencyConversionInput, CurrencyExchangeEvent>().ReverseMap();
			CreateMap<CurrencyConversionEvent, CurrencyConversionCommand>().ReverseMap();
			CreateMap<CurrencyConversionCommand, CurrencyExchangeResult>().ReverseMap();
		}
	}
}

