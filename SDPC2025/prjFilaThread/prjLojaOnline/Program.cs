namespace prjLojaOnline
{

    class Pedido
    {
        public int ID {  get; set; }
        public String Cliente { get; set; }
        public decimal valor {  get; set; }

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


            private static void ProcessaPedido(object estado)
        {

        }
        }
    }
}
