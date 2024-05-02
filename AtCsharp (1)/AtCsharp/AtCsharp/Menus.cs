using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace atCsharp
{
    internal class Menus
    {
        public static void ExibirMenu()
        {
            Console.WriteLine("1 - Inclusão de conta \n " +
                             "2 - Alteração de saldo \n " +
                             "3 - Exclusão de conta \n " +
                             "4- Relatórios gerenciais \n " +
                             "5 - Encerrar o programa");
        }
        public static string ReceberRespMenu()
        {
            string resposta = "";
            try
            {
                Console.WriteLine("Opção:");
                resposta = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return resposta;
        }
        public static void MenuAltercaoSaldo()
        {
            Console.WriteLine("1- Debitar \n" +
                              "2- Creditar  \n");
        }
        public static void MenuRelatoriosGerenciais()
        {
            Console.WriteLine("1 - listar clientes com saldo negativo, \n" +
                              "2 - listar os clientes que tem saldo acima de um determinado valor: \n " +
                              "3- listar todas as contas\r\n");
        }
    }
}

