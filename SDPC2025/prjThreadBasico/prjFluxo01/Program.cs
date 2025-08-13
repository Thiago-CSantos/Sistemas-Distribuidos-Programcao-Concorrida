using System.Text;

namespace prjFluxo01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("iniciando a execução");

            //Chamar processo como novo fluxo de execução
            GestaoThread();
            Console.WriteLine("...Final da Execução");
        }

        private static void GestaoThread()
        {
            // criar uma variavel para gerenciar uma thread pessoal
            Thread fluxo;
            //configurar fluxo de execução (Thread)
            fluxo = new Thread(new ThreadStart(ImprimeNumero));
            // Iniciar fluxo
            fluxo.Start();
        }
        private static void ImprimeNumero()
        {
            for (int i = 0; i < 10; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(i.ToString());
                Console.WriteLine("Nº " + i);
                Console.WriteLine($"Nº {sb.ToString()}");
            }
        }
    }
}
