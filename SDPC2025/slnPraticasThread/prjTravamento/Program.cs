namespace prjTravamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //TrablhoTravado tt = new TrablhoTravado();

            //tt.inciaFLuxos();   
            //String resultado = tt.retornaResultado();

            TrabalhoMonitorado tm = new TrabalhoMonitorado();

            tm.inciaFLuxos();
            String r = tm.retornaResultado();
            Console.WriteLine(r);
        }

        internal class TrablhoTravado
        {
            Thread fluxo1, fluxo2;

            object rA = new object();
            object rB = new object();

            String saida;

            public void inciaFLuxos()
            {
                fluxo1 = new Thread(Procedimento1);
                fluxo1.Start();
                fluxo2 = new Thread(Procedimento2);
                fluxo2.Start();
            }

            public String retornaResultado()
            {
                fluxo1.Join();
                fluxo2.Join();
                return saida;
            }

            public void Procedimento1()
            {
                Thread.Sleep(100);

                lock (rA)
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Travaou o RecusoA");

                    lock (rB)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"Travaou o RecusoB");
                    }


                }
            }

            public void Procedimento2()
            {
                Thread.Sleep(100);

                lock (rB)
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Travaou o RecusoB");

                    lock (rA)
                    {
                        Thread.Sleep(000);
                        Console.WriteLine($"Travaou o RecusoA");
                    }


                }
            }

        }

        internal class TrabalhoMonitorado
        {
            Thread fluxo1, fluxo2;

            object rA = new object();
            object rB = new object();

            String saida;

            public void inciaFLuxos()
            {
                fluxo1 = new Thread(Procedimento1);
                fluxo1.Start();
                fluxo2 = new Thread(Procedimento2);
                fluxo2.Start();
            }

            public String retornaResultado()
            {
                fluxo1.Join();
                fluxo2.Join();
                return saida;
            }

            public void Procedimento1()
            {
                Boolean pdTrabalha = true;

                Thread.Sleep(100);

                while (pdTrabalha)
                {

                    lock (rA)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"Travaou o RecursoA");
                        if(Monitor.TryEnter(rB, 0))
                        {
                            saida = saida + "T1#";
                            pdTrabalha = false;
                            Monitor.Exit(rB);
                        }

                        if (pdTrabalha)
                        {
                            Thread.Yield();
                        }

                        lock (rB)
                        {
                            Thread.Sleep(100);
                            Console.WriteLine($"Travaou o RecursoB");
                        }


                    }
                }
            }

            public void Procedimento2()
            {
                Thread.Sleep(100);

                lock (rB)
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Travaou o RecursoB");

                    lock (rA)
                    {
                        Thread.Sleep(000);
                        Console.WriteLine($"Travaou o RecursoA");
                    }


                }
            }

        }
    }
}
