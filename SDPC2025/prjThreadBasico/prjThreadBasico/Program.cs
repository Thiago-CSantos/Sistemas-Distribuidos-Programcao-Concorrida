using System.Text;

namespace prjThreadBasico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exemplo com a programação tradicional
            // Codigo Sincrono
            Console.WriteLine("iniciando a execução");

            ImprimeNumero();
            Console.WriteLine("...Final da Execução");

        }

        private static void ImprimeNumero()
        {
            for (int i = 0; i < 10; i++) {
                StringBuilder sb = new StringBuilder();
                sb.Append(i.ToString());
                Console.WriteLine("Nº "+ i);
                Console.WriteLine($"Nº {sb.ToString()}");
            }
        }

    }
}
