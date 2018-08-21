using Elo.Business.Contract;
using Elo.Business.ValueObject;
using Elo.Service;
using Elo.Service.Contract;
using System;
using System.Collections.Generic;

namespace Elo.Business
{
    public class CambioBusiness : ICambioBusiness
    {
        private readonly IJsonRatesService service;

        public CambioBusiness(IJsonRatesService service)
        {
            this.service = service;
        }

        public IEnumerable<Cambio> GetTaxasDeCambio(string moeda)
        {
            string[] moedasValidas = { "BRL", "EUR", "ARS" };

            if (string.IsNullOrEmpty(moeda))
                throw new Exception("A moeda precisa ser preenchida.");

            if (Array.IndexOf(moedasValidas, moeda) < 0)
                throw new ArgumentException("A moeda informada é inválida.");
            
            var retorno = new List<Cambio>();

            for (DateTime dtReferencia = DateTime.Now.Date.AddDays(-6); dtReferencia <= DateTime.Now.Date; dtReferencia = dtReferencia.AddDays(1))
            {
                var cambioSolicitado = service.GetCurrencyByHistorical(moeda, dtReferencia.Date.ToString("yyyy-MM-dd"));
                var cambioBase = !moeda.Equals("BRL") ? service.GetCurrencyByHistorical("BRL", dtReferencia.Date.ToString("yyyy-MM-dd")).USDBRL : 1;

                switch (moeda)
                {
                    case "EUR":
                        retorno.Add(new Cambio(moeda, dtReferencia, ConverterCambio(cambioBase, cambioSolicitado.USDEUR)));
                        break;
                    case "ARS":
                        retorno.Add(new Cambio(moeda, dtReferencia, ConverterCambio(cambioBase, cambioSolicitado.USDARS)));
                        break;
                    default:
                        retorno.Add(new Cambio(moeda, dtReferencia, cambioSolicitado.USDBRL));
                        break;
                }
            }

            return retorno;
        }

        private decimal ConverterCambio(decimal baseQuota, decimal quota)
        {
            return baseQuota / quota;
        }
    }
}