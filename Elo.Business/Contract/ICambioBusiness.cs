using Elo.Business.ValueObject;
using System.Collections.Generic;

namespace Elo.Business.Contract
{
    public interface ICambioBusiness
    {
        IEnumerable<Cambio> GetTaxasDeCambio(string moeda);
    }
}