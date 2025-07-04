using PlayGround;
namespace CalculadoraTeste
{
    public class PlaygroundTeste
    {
        private Calculadora _calc;

        public PlaygroundTeste()
        {
            _calc = new Calculadora();
        }


        [Fact]
        public  void Test1()
        {
            //Agrange
            int numA = 10;
            int numB = 5;



            //Act
            int resultado = _calc.Adicao(numA, numB);



            //Assert
            Assert.Equal(15, resultado);
        }

        [Fact]
        public void DivisaoDeDoisNumeros()
        {
            int numA = 100;
            int numB = 0;

            int resultado = _calc.Divisao(numA, numB);

            Assert.Equal(0, resultado);
        }

        [Fact]
        public void TestaDivisaoDeveLancarExcecao()

        {
            // Arrange

            int numA = 7;
            int numB = 0;

            // Act

            int resultado = _calc.Divisao(numA, numB);

            // Assert

            Assert.Equal(0, resultado);
        }

        [Theory]
        [InlineData(10,10,20)]
        [InlineData(15,5,20)]
        [InlineData(10,5,15)]
        public void TestaAdicaoResultadoDeveSerValido(int numA, int numB, int expectativa)       
        {
            


            // Act

            int resultado = _calc.Adicao(numA, numB);

            // Assert

            Assert.Equal(expectativa, resultado);
        }

    }
}