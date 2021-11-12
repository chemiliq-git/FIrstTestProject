﻿using CurrencyExchange.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Services
{
    public interface ICurrencyExchangeService
    {
        public CurrencyExchangeResult GetCurrencyExchanges(CurrencyExchangeInput inputData);
    }
}
