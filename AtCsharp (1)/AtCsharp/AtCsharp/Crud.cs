using System.Net.Http.Headers;

namespace atCsharp
{
    internal class Crud
    {
        public static void CadastrarConta(List<Conta> contas)
        {           
           int tam = contas.Count;
           int id = CadastrarId(contas, tam);
           string nome = CadastrarNome(contas, tam);
           double saldo =  CadastrarSaldo(contas, tam);
           contas.Add(new Conta(id, nome, saldo));
        }
        public static int CadastrarId(List<Conta> contas, int tam)
        {
            bool ehIdValido;
            int id = 0;
            do
            {
                id = Util.EntrarIdCorrentista();
                ehIdValido = Util.ValidarId(contas, id);
                if (ehIdValido)
                {
                    return id;
                }
                Console.WriteLine("ID ja cadastrado!");
            } while (!ehIdValido);
            return id;
        }
        public static string CadastrarNome(List<Conta> contas, int tam)
        {
            bool ehNomeValido;
            string nome = " ";
            do
            {
                 nome = Util.EntrarNomeCorrentista();
                ehNomeValido = Util.ValidarNome(nome);
                if (ehNomeValido)
                {
                    return nome;
                }
                Console.WriteLine($"{nome} é um nome inválido! Tente novamente!!!");
            } while (!ehNomeValido);
            return nome;
        }
        public static double CadastrarSaldo(List<Conta> contas, int tam)
        {
            bool ehSaldoValido;
            double saldo = 0;
            do
            {
                saldo = Util.EntrarSaldoCorrentista();
                ehSaldoValido = Util.ValidarSaldo(saldo);
                if (ehSaldoValido)
                {
                    return saldo;
                }
                Console.WriteLine("Saldo não válido!");
            } while (!ehSaldoValido);
            return saldo;
        }
        public static void AlterarSaldo(List<Conta> contas)
        {
            bool ehListaVazia = Util.VerificarListaVazia(contas);
            if (ehListaVazia)
            {
                Console.WriteLine("Nenhuma conta Cadastrada!");
                return;
            }
            Menus.MenuAltercaoSaldo();
            string opc = Menus.ReceberRespMenu();
            if (opc == "1")
            {
                Util.DebitarSaldo(contas);
                return;
            }
            if (opc == "2")
            {
                Util.CreditarSaldo(contas);
                return;
            }
        }
        public static void ExcluirConta(List<Conta> contas)
        {
            int id = Util.EntrarIdCorrentista();
            int posicaoID = Util.ProucurarPosiçãoId(contas, id);
            double saldo = contas[posicaoID].Saldo;
            if (posicaoID > -1 && saldo == 0)
            {
                Util.ApagarConta(contas, posicaoID);
                return;
            }
            Console.WriteLine("Saldo maior que 0 ou conta não encontrada!");
        }
        public static void RelatoriosGerenciais(List<Conta> contas)
        {
            Menus.MenuRelatoriosGerenciais();
            string resposta = Menus.ReceberRespMenu();
            if (resposta.Equals("1"))
            {
                Util.ListarContaSaldoNegativo(contas);
                return;
            }
            if (resposta.Equals("2"))
            {
                Util.ListarContaAcimaDe(contas);
                return;
            }
            if (resposta.Equals("3"))
            {
                Util.ListarTodasAsContas(contas);
                return;
            }
            Console.WriteLine("Opção inválida!");
        }

    }
}
    