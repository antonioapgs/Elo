using Elo.Service.Client;
using Elo.Service.Contract;
using Elo.Service.Shared;
using Microsoft.Extensions.Options;

namespace Elo.Service
{
    public class JsonRatesService : IJsonRatesService
    {
        private readonly JsonRatesSettings _jsonRatesSettings;

        public JsonRatesService(IOptions<JsonRatesSettings> configuration)
        {
            _jsonRatesSettings = configuration.Value;
        }

        /// <summary>
        /// Serviço para recuperar as taxas de câmbio no endpoint Historical do JsonRates
        /// </summary>
        /// <param name="currency">Moeda a qual deseja o câmbio</param>
        /// <param name="date">Data referência do câmbio</param>
        /// <param name="source">Moeda de origem</param>
        /// <returns>Instância do objeto Quotes, contendo a data e o valor do câmbio</returns>
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
