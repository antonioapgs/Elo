using Elo.Business.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elo.Business.Tests.Builder
{
    public class CambioBuilder
    {
        public List<Cambio> TaxasDeCambio { get; set; }

        public CambioBuilder(string moeda)
        {
            TaxasDeCambio = new List<Cambio>();

            for (DateTime dtReferencia = DateTime.Now.Date.AddDays(-6); dtReferencia <= DateTime.Now.Date; dtReferencia = dtReferencia.AddDays(1))
            {
                TaxasDeCambio.Add(new Cambio(moeda, dtReferencia, new Random().Next()));
            }
        }
    }
}
