using System.Text;

namespace prjFluxo02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("iniciando a execução");
            Console.Write("Digite um valor: ");
            int valor = Convert.ToInt32(Console.ReadLine());
            //Chamar processo como novo fluxo de execução
            GestaoThreadParametro(valor);
            Console.WriteLine("...Final da Execução");
        }

        private static void GestaoThreadParametro(int valor)
        {
            Thread fluxo = new Thread(new ParameterizedThreadStart(ImprimeNumero));

            fluxo.Start(valor);
        }

        private static void ImprimeNumero(Object valor)
        {
            int n = Convert.ToInt32(valor);
            for (int i = 0; i < n; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(i.ToString());
                Console.WriteLine("Nº " + i);
                Console.WriteLine($"Nº {sb.ToString()}");
            }
        }
    }
}
