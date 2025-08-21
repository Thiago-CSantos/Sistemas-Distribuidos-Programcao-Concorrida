namespace prjLojaOnline
{

    class Pedido
    {
        public int ID { get; set; }
        public String Cliente { get; set; }
        public decimal valor { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pedido> pedido = new List<Pedido>()
            {
                new Pedido {ID = 1, Cliente = "Ana", valor = 450.00m},
                new Pedido {ID = 2, Cliente = "Bruno", valor = 150.00m},
                new Pedido {ID = 3, Cliente = "Carla", valor = 99.00m},
            };

            foreach (var item in pedido)
            {
                ThreadPool.QueueUserWorkItem(ProcessaPedido, item);
            }
            Console.WriteLine("Aguardando processamento...");
            Thread.Sleep(1000);
            Console.WriteLine("Todos os pedidos foram processados");


        }
        private static void ProcessaPedido(object estado)
        {
            if (estado is Pedido pedido)
            {
                Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId} -> Processando o pedido {pedido.valor:f2} ...");
                // Aqui seria o processo da regra de negocio
                // para processar o pedido
                // 1) Romaneio de separação para pedido
                // 2) Emissão da NFS-e
                // 3) Pedido de coleta na logistica
                // Total de tempo de processamento: 4 segundos
                Thread.Sleep(4000); // SImulando o tempo de processamento
                Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] -> Pedido {pedido.ID} processando com sucesso!");
            }
        }
    }
}
