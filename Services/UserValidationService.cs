namespace ez_parking_api.Services
{
    public class UserValidationService
    {
        public bool ValidarCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());
            if(cpf.Length != 11)
            {
                return false;
            }
            if(cpf.Distinct().Count() == 1)
            {
                return false;
            }

            int primeiroDigito;
            int segundoDigito;
            char[] cpfNaoValidado = cpf.ToCharArray();
            char[] cpfChar = new char[cpf.Length - 2];
            for (int i = 0; i < cpfChar.Length; i++)
            {
                cpfChar[i] = cpfNaoValidado[i];
            }
            int[] cpfArr = new int[cpfChar.Length];
            int[] checker = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < cpfChar.Length; i++)
            {
                cpfArr[i] = cpfChar[i] - '0';
                checker[i] *= cpfArr[i];
                soma += checker[i];
            }
            int resto = soma % 11;
            primeiroDigito = 11 - resto;
            if (primeiroDigito > 10)
            {
                primeiroDigito = 0;
            }
            soma = 0;
            resto = soma;
            int[] cpfArr2 = new int[cpfChar.Length + 1];
            int[] checker2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < cpfChar.Length + 1; i++)
            {
                if (i == cpfChar.Length)
                {
                    cpfArr2[i] = primeiroDigito;
                    checker2[i] *= primeiroDigito;
                }
                else
                {
                    cpfArr2[i] = cpfChar[i] - '0';
                    checker2[i] *= cpfArr[i];
                }
                soma += checker2[i];
            }
            resto = soma % 11;
            segundoDigito = 11 - resto;
            if (segundoDigito > 10)
            {
                segundoDigito = 0;
            }
            if ((cpfNaoValidado[9] - '0') == primeiroDigito && (cpfNaoValidado[10] - '0') == segundoDigito)
            {
                return true;
            }
            return false;
        }
    }

}
