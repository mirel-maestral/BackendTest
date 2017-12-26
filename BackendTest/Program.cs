using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackendTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // Running on 4 threads, consider them as separate backend proceses running on separate machines
            // se we cannot do any kind of orchestration by using ConcurentQueue or any other concurrent collection
            // from System.Collection.Concurrent

            // PRETPOSTAVITE DA NEMA NiKAKAV MUHANIZAM ORKESTRACIJE
            // KOJI SU MOGUCI ???

            var tasks = new[] {
                Task.Run(() =>  DoWork()),
                Task.Run(() =>  DoWork()),
                Task.Run(() =>  DoWork()),
                Task.Run(() =>  DoWork())
            };

            //Task.WaitAll(tasks); - Since each task will run infinite loop lets not do this

            Console.WriteLine("Hit the key to end execution!");
            Console.ReadKey();
        }


        static void DoWork()
        {
            while (true)
            {
                string serviceName = $"Service{Thread.CurrentThread.ManagedThreadId}";
                int orderId = DBHelper.GetOrder();
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} obtained order: {orderId} for processing");
                ProcessOrder(orderId, serviceName);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished processing the order: {orderId}");
            }
        }

        public static bool ProcessOrder(int orderId, string serviceName)
        {
            //Sleep the thread randomly to simulate processing
            int seconds = new Random().Next(1, 6);
            Thread.Sleep( TimeSpan.FromSeconds(seconds) );
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} was sleeping for {seconds}");

            DBHelper.MarkOrderAsProcessed(orderId, serviceName);
            return true;
        }
    }
}
