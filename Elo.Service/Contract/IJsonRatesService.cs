using Elo.Service.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elo.Service.Contract
{
    public interface IJsonRatesService
    {
        Quotes GetCurrencyByHistorical(string currency, string date, string source = "USD");
    }
}
