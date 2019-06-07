using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Resto
{
    class Program
    {

        public static void getMyName() { }

        public static void WriteConsoleTable(int trNum)
        {
            Console.WriteLine("Table {0}", trNum);
            //LogEvents(tr);
        }

        public static void WriteConsoleTask(Task task)
        {
            Console.WriteLine("#Task {0} : {1}", task.Id, task.Status);
            //LogEvents(tr);
        }

        public static void CreateTask(Thread tr)
        {
            var source1 = new CancellationTokenSource();
            var token1 = source1.Token;
            var source2 = new CancellationTokenSource();
            var token2 = source1.Token;

            Task[] tasks = new Task[3];

            for (int i = 0; i < 3; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        tasks[i] = Task.Run(() => Thread.Sleep(2000));

                        //WriteConsoleTask(tasks[i]);
                        break;
                    case 1:
                        tasks[i] = new Task<long>(() => { long sum = 0; return sum; });
                        tasks[i].RunSynchronously();
                        //WriteConsoleTask(tasks[i]);
                        break;
                    case 2:
                        tasks[i] = Task.Run(() => {
                            Thread.Sleep(2000);
                            if (token2.IsCancellationRequested)
                                token2.ThrowIfCancellationRequested();
                            Thread.Sleep(2000);}, token2);

                        //WriteConsoleTask(tasks[i]);
                        break;
                }
            }

            try
            {
                
               //Task.WaitAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Status Taches");
            foreach (var t in tasks)
            {
                LogEvents(t);
                Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);
            }
        }

        public static void LogEvents(Task task)
        {
            Service.Serializer ser = new Service.Serializer();
            //string str="test" + tr.ManagedThreadId;
            //str.ToString("test");
            ser.Save(task);
        }

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[4];

            for (int k = 0; k < 4; k++)
            {
                switch (k % 4)
                {
                    case 0:
                        threads[k] = new Thread(new ThreadStart(getMyName));
                        threads[k].Start();
                        threads[k].Priority = ThreadPriority.Highest;
                        CreateTask(threads[k]);
                        WriteConsoleTable(threads[k].ManagedThreadId);
                        break;

                    case 1:
                        threads[k] = new Thread(new ThreadStart(getMyName));
                        threads[k].Start();
                        threads[k].Priority = ThreadPriority.Lowest;
                        CreateTask(threads[k]);
                        WriteConsoleTable(threads[k].ManagedThreadId);
                        break;

                    case 2:
                        threads[k] = new Thread(new ThreadStart(getMyName));
                        threads[k].Start();
                        threads[k].Priority = ThreadPriority.AboveNormal;
                        Thread.Sleep(1000);
                        CreateTask(threads[k]);
                        WriteConsoleTable(threads[k].ManagedThreadId);
                        break;

                    case 3:
                        threads[k] = new Thread(new ThreadStart(getMyName));
                        threads[k].Start();
                        threads[k].Priority = ThreadPriority.BelowNormal;
                        CreateTask(threads[k]);
                        WriteConsoleTable(threads[k].ManagedThreadId);
                        break;
                }
            }
        

            
            

            Console.WriteLine("Main thread ends");
            Console.Read();
        }

        
    }
}
