using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace PlayGround
{
    public class ValidarCPF_Teste
    {
        private ValidadorCPF _validador;


        public ValidarCPF_Teste()
        {
            _validador = new ValidadorCPF();
        }


        [Fact]
        public void ValidarTesteDeveRetornarFalse()
        {
            
            // Arrange
            string cpf = null;

            // Act
            bool resultado = _validador.Validar(cpf);


            // Assert
            Assert.False(resultado);

        }


        [Theory]
        [InlineData("98765432199", true)]
        [InlineData("123.456.789-09", true)]


        public void ValidarTesteDeveRetornarTrue(string cpf, bool expectativa)

        {
         

            // Act
            bool resultado = _validador.Validar(cpf);


            // Assert
            Assert.True(resultado);
        }



        [Theory]
        [InlineData("11111111111", false)]
        [InlineData("12345678900", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("123", false)]
        [InlineData("123456789012", false)]
        [InlineData("ABCDEFGHIJK", false)]

        public void ValidarTesteDeveRestornarFalse(string cpf, bool expectativa)

        {
            // Act
            bool resultado = _validador.Validar(cpf);

            // Assert
            Assert.False(resultado);
        }

    }
}
