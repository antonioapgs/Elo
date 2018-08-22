using System;

namespace Elo.Business.ValueObject
{
    public class Cambio
    {
        public Cambio(string descricao, DateTime dataCambio, decimal valor)
        {
            this.Descricao = descricao;
            this.DataCambio = dataCambio;
            this.Valor = valor;
        }

        public string Descricao { get; }
        public DateTime DataCambio { get; }
        public decimal Valor { get; }
    }
}