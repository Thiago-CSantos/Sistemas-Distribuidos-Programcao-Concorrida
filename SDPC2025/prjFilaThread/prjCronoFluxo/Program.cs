using System.Diagnostics;

namespace prjCronoFluxo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch crono = new Stopwatch();

            Console.WriteLine("Tradicional>>>>>");
            crono.Start();
            FluxoTradicional();
            crono.Stop();

            Console.WriteLine($"Tempo de consumo é: {crono.ElapsedTicks.ToString()}");
            crono.Reset();

            Console.WriteLine("Fila Threads >>>>>");
            crono.Start();
            FluxoFila();
            crono.Stop();
            Console.WriteLine($"Tempo de consumo é: {crono.ElapsedTicks.ToString()}");

        }

        // Thread tradicional
        private static void FluxoTradicional()
        {
            for (int i = 0; i < 10; i++)
            {

                Thread fluxo = new Thread(GeraNumero);
                fluxo.Start();

            }
        }

        // FIla Threads
        private static void FluxoFila()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(GeraNumero));
            }
        }

        // Processo a ser executado
        private static void GeraNumero(object estado)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} ID da Thread[{Thread.CurrentThread.ManagedThreadId}]");
            }
        }

    }
}
