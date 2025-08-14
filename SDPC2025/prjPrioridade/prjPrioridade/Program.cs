namespace prjPrioridade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // criar 3 THreads para o mesmo precesso com prioridades diferentes

            Thread t1 = new Thread(Processo);
            Thread t2 = new Thread(Processo);
            Thread t3 = new Thread(Processo);

            // Personalizando dados de controle das Threads
            t1.Name = "T1A alta";
            t2.Name = "T2B normal";
            t3.Name = "T3C baixo";

            t1.Priority = ThreadPriority.Highest; // prioridade alta
            t3.Priority = ThreadPriority.Lowest;  // prioridade normal

            // Dados partida das Threads
            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine($"Prioridade de t1 é {t1.Priority} [{t1.Name}] ");
            Console.WriteLine($"Prioridade de t2 é {t2.Priority} [{t2.Name}] ");
            Console.WriteLine($"Prioridade de t3 é {t3.Priority} [{t3.Name}] ");

        }

        private static void Processo()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine($"{i} Thread {Thread.CurrentThread.Name} - {i}");
            }
            Console.WriteLine();
        }
    }
}
