using System;

namespace Elo.Business.ValueObject
{
    public class Cambio
    {
        public Cambio(string descricao, DateTime data, decimal valor)
        {
            this.Descricao = descricao;
            this.Data = data;
            this.Valor = valor;
        }

        public string Descricao { get; }
        public DateTime Data { get; }
        public decimal Valor { get; }
    }
}