using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace atCsharp
{
    internal class Arquivos
    {
        const String NOME_ARQ = "contas.csv";
        const String DIR = "C:\\Users\\Diego\\Documents\\AtCsharp\\AtCsharp\\arquivo";
        public static void LerArquivo(List<Conta> contas)
        {
            string caminho = Path.Combine(DIR, NOME_ARQ);
            if (!File.Exists(caminho))
            {
                Console.WriteLine("Erro: arquivo não existe");
            }
            try
            {
                using (var arquivo = new StreamReader(caminho))
                { 
                    string linha = arquivo.ReadLine();
                    while (linha != null)
                    { 
                        string[] campos = linha.Split(';');
                        Conta contasB = new Conta(int.Parse(campos[0]), campos[1], double.Parse(campos[2]));
                        contas.Add(contasB);
                        linha = arquivo.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void GravarArquivo(List<Conta> contas)
        {

            string caminho = Path.Combine(DIR, NOME_ARQ);
            try
            {
                using (var arquivo = new StreamWriter(caminho))
                {
                    for(int i = 0; i < contas.Count; i++)
                    {
                        arquivo.WriteLine(contas[i].ID + ";" + contas[i].Name + ";" + contas[i].Saldo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}


