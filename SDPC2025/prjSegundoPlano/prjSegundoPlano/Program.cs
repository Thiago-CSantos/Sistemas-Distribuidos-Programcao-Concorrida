using System.ComponentModel;

namespace prjSegundoPlano
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var segPlano = new BackgroundWorker();

            segPlano.WorkerReportsProgress = true;
            segPlano.WorkerSupportsCancellation = true;

            segPlano.DoWork += servicoPessoal;
            segPlano.ProgressChanged += progresso;
            segPlano.RunWorkerCompleted += processoCompleto;
            segPlano.RunWorkerAsync();
            Console.WriteLine("C canela o processo");

            while (segPlano.IsBusy)
            {
                if (Console.ReadKey(true).KeyChar == 'C')
                {
                    segPlano.CancelAsync();
                }
            }
            Console.WriteLine(">>> FIM");
        }

        // Processo para execução em Segundo Plano
        private static void servicoPessoal(Object? sender, DoWorkEventArgs e)
        {

        }

        private static void processoCompleto(object? sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void progresso(object? sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
