using Playground;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlayGround
{
    public class TesteCalculadora
    {
        private CalculadoraFinanceira _validador;

        public TesteCalculadora()
        {
            _validador = new();
        }

        [Theory]
        [InlineData(1000.0, 0.01, 12, 1120.00)]
        [InlineData(0.0, 0.01, 12, 0.00)]

        public void TestarJurosSimples(decimal capital, decimal taxa, int periodo, decimal expectativa)
        {



            // Act

            decimal resultado = _validador.CalcularJurosSimples(capital, taxa, periodo);

            // Assert

            Assert.Equal(expectativa, resultado);
        }


        [Fact] 
        public void TestarJurosSimplesExcecao()

        {
            // Arrange

            decimal capital = -100;
            decimal taxa = 0.01m;
            int periodo = 12; 

            // Act

            decimal resultado = _validador.CalcularJurosSimples(capital, taxa, periodo);

            // Assert

            Assert.Equal(0, resultado);
        }


        [Fact]
        public void TestarJurosCompostos()

        {
            // Arrange

            decimal capital = 1000;
            decimal taxa = 0.01m;
            int periodo = 2;
            decimal expectativa = 1020.10m;

            // Act

            decimal resultado = _validador.CalcularJurosCompostos(capital, taxa, periodo);

            // Assert

            Assert.Equal(expectativa, resultado);
        }


        [Fact]
        public void TestarJurosCompostosExcecao()

        {
            // Arrange

            decimal capital = 1000;
            decimal taxa = -0.01m;
            int periodo = 2;

            // Act

            decimal resultado = _validador.CalcularJurosCompostos(capital, taxa, periodo);

            // Assert

            Assert.Equal(0, resultado);
        }


        [Theory]
        [InlineData(200, 0.10, 180.00)]
        [InlineData(100, 1.00, 0.00)]
        public void TestarAplicarDesconto(decimal valorOriginal, decimal percentualDesconto, decimal expectativa)

        {


            // Act

            decimal resultado = _validador.AplicarDesconto(valorOriginal, percentualDesconto);

            // Assert

            Assert.Equal(expectativa, resultado);
        }


        [Fact] 
        public void TestarAplicarDescontoExcecao()

        {
            // Arrange

            decimal valorOriginal = 100;
            decimal percentualDesconto = 1.50m;

            // Act

            decimal resultado = _validador.AplicarDesconto(valorOriginal, percentualDesconto);

            // Assert

            Assert.Equal(0, resultado);
        }
    }
}
