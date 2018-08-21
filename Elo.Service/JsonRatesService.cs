using Elo.Service.Client;
using Elo.Service.Contract;
using Elo.Service.Shared;
using Microsoft.Extensions.Options;
using System;

namespace Elo.Service
{
    public class JsonRatesService : IJsonRatesService
    {
        private readonly JsonRatesSettings _jsonRatesSettings;

        public JsonRatesService(IOptions<JsonRatesSettings> configuration)
        {
            _jsonRatesSettings = configuration.Value;
        }

        public Quotes GetCurrencyByHistorical(string currency, string date, string source = "USD")
        {
            var fullUrl = string.Format("{0}/historical?access_key={1}&date={2}&source={3}&currencies={4}&format=1",
                    _jsonRatesSettings.Url,
                    _jsonRatesSettings.Token,
                    date,
                    source,
                    currency);

            var result = ApiClient.GetJson(fullUrl);

            return new Quotes()
            {
                Date = result.Date,
                USDARS = result.USDARS,
                USDBRL = result.USDBRL,
                USDEUR = result.USDEUR
            };
        }
    }
}
