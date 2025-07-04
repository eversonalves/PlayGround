using System.Linq;
using System.Text.RegularExpressions;

namespace PlayGround
{
    public class ValidadorCPF
    {
        /// <summary>
        /// Valida se um CPF é válido.
        /// </summary>
        /// <param name="cpf">A string contendo o CPF a ser validado.</param>
        /// <returns>True se o CPF for válido, False caso contrário.</returns>
        public bool Validar(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (ex: "111.111.111-11")
            if (cpf.All(c => c == cpf[0]))
                return false;

            // Calcula o primeiro dígito verificador
            int[] multiplicadores1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[9].ToString()) != digito1)
                return false;

            // Calcula o segundo dígito verificador
            int[] multiplicadores2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            tempCpf = cpf.Substring(0, 10);
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return int.Parse(cpf[10].ToString()) == digito2;
        }
    }
}
