using System.Text.RegularExpressions;
namespace atCsharp
{
    internal class Util
    {
        public static int EntrarIdCorrentista()
        {
            int id = 0;
            try
            {
                Console.WriteLine("Informe o ID da conta: ");
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Tente novamente!");
            }
            return id;
        }
        public static bool ValidarId(List<Conta> contas, int id)
        {
            for (int i = 0; i < contas.Count; i++)
            {
                if (contas[i].ID == id || id < 1)
                {
                    return false;
                }
            }
            return true;
        }
        public static int ProucurarPosiçãoId(List<Conta> contas, int id)
        {
            for (int i = 0; i < contas.Count; i++)
            {
                if (contas[i].ID == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public static string EntrarNomeCorrentista()
        {
            string nome = "";
            try
            {
                Console.WriteLine("Nome do correntista: ");
                nome = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return nome;
        }
        public static bool ValidarNome(string nome)
        {
            var regex = new Regex("^[a-zA-Z]+ [a-zA-Z]+$");
            bool ehNomeValido = regex.IsMatch(nome);
            return ehNomeValido;
        }
        public static double EntrarSaldoCorrentista()
        {
            double saldo = double.MinValue;
            try
            {
                Console.WriteLine("Informe o saldo da conta: ");
                saldo = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + "Saldo inválido, tente novamente!");
            }
            return saldo;
        }
        public static bool ValidarSaldo(double saldo)
        {
            if (saldo >= 0)
            {
                return true;
            }
            return false;
        }
        public static void DebitarSaldo(List<Conta> contas)
        {
            int id = EntrarIdCorrentista();
            int posicaoID = ProucurarPosiçãoId(contas, id);
            if (posicaoID > -1)
            {
                double valor = ReceberValorDebito();
                double novoSaldo = contas[posicaoID].Debitar(valor);
                contas[posicaoID].Saldo = novoSaldo;
                return;
            }
            Console.WriteLine("Conta não encontrada!");
        }
        public static double ReceberValorDebito()
        {
            double valor = 0;
            do
            {
                try
                {
                    Console.WriteLine("Informe o valor a ser debitado: ");
                    valor = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            } while (valor <= 0);
            return valor;
        }
        public static void CreditarSaldo(List<Conta> contas)
        {
            int id = Util.EntrarIdCorrentista();
            int posicaoID = Util.ProucurarPosiçãoId(contas, id);

            if (posicaoID > -1)
            {
                double valor = ReceberValorCredito();
                double novoSaldo = contas[posicaoID].Creditar(valor);
                contas[posicaoID].Saldo = novoSaldo;
                return;
            }
        }
        public static double ReceberValorCredito()
        {
            double valor = 0;
            do
            {
                try
                {
                    Console.WriteLine("Informe o valor a ser Creditado: ");
                    valor = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            } while (valor <= 0);
            return valor;
        }
        public static bool VerificarListaVazia(List<Conta> contas)
        {
            if (contas.Count == 0)
            {
                return true;
            }
            return false;
        }
        public static void ApagarConta(List<Conta> contas, int posicaoId)
        {
            contas.Remove(contas[posicaoId]);
        }
        public static void ListarContaSaldoNegativo(List<Conta> contas)
        {
            bool existeContaNegativa = false;
            for (int i = 0; i < contas.Count; i++)
            {
                if (contas[i].Saldo < 0)
                {
                    Console.WriteLine(contas[i]);
                    existeContaNegativa = true;
                }
            }
            if (!existeContaNegativa)
            {
                Console.WriteLine("Nenhuma conta com saldo negativo encontrada!");
            }

        }
        public static void ListarContaAcimaDe(List<Conta> contas)
        {
            double saldoBase = PegarSaldoBase();
            bool existeConta = false;
            for (int i = 0; i < contas.Count; i++)
            {
                if (contas[i].Saldo >= saldoBase)
                {
                    Console.WriteLine(contas[i]);
                    existeConta = true;
                }
            }
            if (!existeConta)
            {
                Console.WriteLine("Nenhuma conta a partir desse valor foi encontrada!");
            }
        }
        public static double PegarSaldoBase()
        {
            double saldoBase = 0;
            try
            {
                Console.WriteLine("Listar contas a partir do saldo: ");
                saldoBase = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Saldo inválido!");
            }
            return saldoBase;
        }
        public static void ListarTodasAsContas(List<Conta> contas)
        {
            for (int i = 0; i < contas.Count; i++)
            {
                Console.WriteLine(contas[i]);
            }
        }

    }
}
