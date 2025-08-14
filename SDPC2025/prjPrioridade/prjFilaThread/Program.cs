namespace prjFilaThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Inicio da execução do programa[{Thread.CurrentThread.ManagedThreadId}]");
            // Execução de um processo em fila de Threads

            GerenciaFila();

            // Sinaliza o fim da execução

            Console.WriteLine($"Fim da execução do programa[{Thread.CurrentThread.ManagedThreadId}]");

        }

        private static void GerenciaFila()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ImprimeNumeros));

        }

        private static void ImprimeNumeros(object state)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{i} [{Thread.CurrentThread.ManagedThreadId}]\t");
            }
            Console.WriteLine();
        }
    }
}
