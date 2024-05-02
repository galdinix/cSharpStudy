namespace atCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Conta> contas = new List<Conta>();
            Arquivos.LerArquivo(contas);
            string resposta;
            do
            {
                Menus.ExibirMenu();
                resposta = Menus.ReceberRespMenu();
                switch (resposta)
                {
                    case "1":
                        Crud.CadastrarConta(contas);
                        break;
                    case "2":
                        Crud.AlterarSaldo(contas);
                        break;
                    case "3":
                        Crud.ExcluirConta(contas);
                        break;
                    case "4":
                        Crud.RelatoriosGerenciais(contas);
                        break;
                    case "5":
                        break;
                }
            } while (resposta != "5");
            Arquivos.GravarArquivo(contas);
        }
    }
}