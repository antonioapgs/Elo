using Elo.Business.Contract;
using Elo.Business.Tests.Builder;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

namespace Elo.Business.Tests
{
    public class CambioBusinessUnitTest
    {
        private const string MOEDA_EMPTY = "";
        private const string MOEDA_INVALIDA = "XPTO";
        private const string MOEDA_VALIDA = "EUR";

        private ICambioBusiness mock;

        public CambioBusinessUnitTest()
        {
            mock = Substitute.For<ICambioBusiness>();

            mock.GetTaxasDeCambio(null)
                .Returns(s => { throw new Exception("A moeda precisa ser preenchida."); });

            mock.GetTaxasDeCambio(MOEDA_EMPTY)
                .Returns(s => { throw new Exception("A moeda precisa ser preenchida."); });

            mock.GetTaxasDeCambio(MOEDA_INVALIDA)
                .Returns(s => { throw new ArgumentException("A moeda informada é inválida."); });

            mock.GetTaxasDeCambio(MOEDA_VALIDA)
                .Returns(s => new CambioBuilder(MOEDA_VALIDA).TaxasDeCambio);
        }

        [Fact]
        public void TestarParametroNull()
        {
            Exception ex = Assert.Throws<Exception>(() => mock.GetTaxasDeCambio(null));
            Assert.Equal("A moeda precisa ser preenchida.", ex.Message);
        }

        [Fact]
        public void TestarParametroEmpty()
        {
            Exception ex = Assert.Throws<Exception>(() => mock.GetTaxasDeCambio(MOEDA_EMPTY));
            Assert.Equal("A moeda precisa ser preenchida.", ex.Message);
        }

        [Fact]
        public void TestarParametroInvalido()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => mock.GetTaxasDeCambio(MOEDA_INVALIDA));
            Assert.Equal("A moeda informada é inválida.", ex.Message);
        }

        [Fact]
        public void TestarParametroValido()
        {
            Assert.True(mock.GetTaxasDeCambio(MOEDA_VALIDA) != null);
            Assert.Equal(7, mock.GetTaxasDeCambio(MOEDA_VALIDA).Count());
        }
    }
}