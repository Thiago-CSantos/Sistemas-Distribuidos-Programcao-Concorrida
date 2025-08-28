namespace prjNumCOres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCores = Environment.ProcessorCount;

            Console.WriteLine($"A maquina atual possui {numCores} nucleos logicos!! ");

            for (int i = 0; i < numCores; i++)
            {
                Thread fluxo = new Thread(Processor);
                fluxo.Start();
            }
        }


        private static void Processor(object ordem)
        {
            Console.WriteLine($"Executando pela Thread {ordem} [{Thread.CurrentThread.ManagedThreadId}]");
        }

    }
}
