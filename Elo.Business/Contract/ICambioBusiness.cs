using Elo.Business.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elo.Business.Contract
{
    public interface ICambioBusiness
    {
        IEnumerable<Cambio> GetTaxasDeCambio(string moeda);
    }
}