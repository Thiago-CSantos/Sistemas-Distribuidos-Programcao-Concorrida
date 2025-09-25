using System.Diagnostics;

namespace pjSicronos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch crono = new Stopwatch();
            Console.WriteLine("Fluxo principal iniciado, pressione ENTER");
            Console.ReadLine();

            crono.Start();
            ExibirDias();
            ExibirMeses();
            ExibirCapitais();
            crono.Stop();

            Console.WriteLine($"Tempo total de execução: {crono.ElapsedTicks} ciclos");

            // 2 - Execução Assincrono - Paralela [Explicita]
            crono.Restart();
            crono.Start();

            Parallel.Invoke(
                new Action(ExibirDias),
                new Action(ExibirMeses),
                new Action(ExibirCapitais)
            );

            crono.Stop();
            Console.WriteLine($"Fase 2 - total de execução: {crono.ElapsedTicks} ciclos");


            // 3 - Execução em Paralelo com notação lambda
            crono.Restart();
            crono.Start();

            Parallel.Invoke(
                () => ExibirDias(),
                () => ExibirMeses(),
                () => ExibirCapitais()
            );

            Console.WriteLine($"Fase 3 - total de execução: {crono.ElapsedTicks} ciclos");

            Console.WriteLine("FLuxo principal finalizado");
        }

        private static void ExibirDias()
        {
            string[] dias = { "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado", "Domingo" };

            foreach (string dia in dias)
            {
                Console.WriteLine($"Dia da semana: {dia}");

                Thread.Sleep(1500);
            }
        }

        private static void ExibirMeses()
        {
            string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

            foreach (string mes in meses)
            {
                Console.WriteLine($"Mês: {mes}");
                Thread.Sleep(1500);
            }
        }

        private static void ExibirCapitais()
        {
            string[] capitais = {
                "Rio Branco", "Maceió", "Manaus", "Salvador", "Fortaleza", "Brasília",
                "Vitória", "Goiânia", "São Luís", "Cuiabá", "Campo Grande", "Belo Horizonte",
                "Belém", "João Pessoa", "Curitiba", "Recife", "Teresina", "Rio de Janeiro",
                "Natal", "Porto Alegre", "Macapá", "Cuiabá", "Aracaju", "Boa Vista", "Florianópolis",
                "São Paulo", "Porto Velho", "Palmas", "Boa Vista"
            };

            foreach (string capital in capitais)
            {
                Console.WriteLine($"Capital: {capital}");
                Thread.Sleep(1500);
            }
        }
    }
}
