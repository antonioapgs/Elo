using Elo.Service.Client;

namespace Elo.Service.Contract
{
    public interface IJsonRatesService
    {
        Quotes GetCurrencyByHistorical(string currency, string date, string source = "USD");
    }
}
