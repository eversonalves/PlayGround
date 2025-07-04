using System;

namespace Playground
{
    public class CalculadoraFinanceira
    {
        /// <summary>
        /// Calcula o valor final com juros simples.
        /// </summary>
        /// <param name="capitalInicial">O capital inicial.</param>
        /// <param name="taxaJurosMensal">A taxa de juros mensal (ex: 0.01 para 1%).</param>
        /// <param name="periodoMeses">O período em meses.</param>
        /// <returns>O valor final com juros.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Lançada se os parâmetros forem negativos.</exception>
        public decimal CalcularJurosSimples(decimal capitalInicial, decimal taxaJurosMensal, int periodoMeses)
        {
            if (capitalInicial < 0) throw new ArgumentOutOfRangeException(nameof(capitalInicial), "O capital inicial não pode ser negativo.");
            if (taxaJurosMensal < 0) throw new ArgumentOutOfRangeException(nameof(taxaJurosMensal), "A taxa de juros não pode ser negativa.");
            if (periodoMeses < 0) throw new ArgumentOutOfRangeException(nameof(periodoMeses), "O período não pode ser negativo.");

            return capitalInicial * (1 + (taxaJurosMensal * periodoMeses));
        }

        /// <summary>
        /// Calcula o valor final com juros compostos.
        /// </summary>
        /// <param name="capitalInicial">O capital inicial.</param>
        /// <param name="taxaJurosMensal">A taxa de juros mensal (ex: 0.01 para 1%).</param>
        /// <param name="periodoMeses">O período em meses.</param>
        /// <returns>O valor final com juros.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Lançada se os parâmetros forem negativos.</exception>
        public decimal CalcularJurosCompostos(decimal capitalInicial, decimal taxaJurosMensal, int periodoMeses)
        {
            if (capitalInicial < 0) throw new ArgumentOutOfRangeException(nameof(capitalInicial), "O capital inicial não pode ser negativo.");
            if (taxaJurosMensal < 0) throw new ArgumentOutOfRangeException(nameof(taxaJurosMensal), "A taxa de juros não pode ser negativa.");
            if (periodoMeses < 0) throw new ArgumentOutOfRangeException(nameof(periodoMeses), "O período não pode ser negativo.");

            return capitalInicial * (decimal)Math.Pow(1 + (double)taxaJurosMensal, periodoMeses);
        }

        /// <summary>
        /// Calcula o valor líquido após um desconto percentual.
        /// </summary>
        /// <param name="valorOriginal">O valor antes do desconto.</param>
        /// <param name="percentualDesconto">O percentual de desconto (ex: 0.10 para 10%).</param>
        /// <returns>O valor após o desconto.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Lançada se o valor original for negativo ou o percentual de desconto for inválido.</exception>
        public decimal AplicarDesconto(decimal valorOriginal, decimal percentualDesconto)
        {
            if (valorOriginal < 0) throw new ArgumentOutOfRangeException(nameof(valorOriginal), "O valor original não pode ser negativo.");
            if (percentualDesconto < 0 || percentualDesconto > 1) throw new ArgumentOutOfRangeException(nameof(percentualDesconto), "O percentual de desconto deve estar entre 0 e 1.");

            return valorOriginal * (1 - percentualDesconto);
        }
    }
}