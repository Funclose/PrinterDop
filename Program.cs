using System.Security.Cryptography.X509Certificates;

namespace SemaphoreDop
{
     class Program
    {
        
        static void Main(string[] args)
        {
            int avgTaskForPrinter = 10;
            for (int i = 0; i < avgTaskForPrinter; i++)
            {
                Printer printer = new Printer(i);
            }

        }
    }
    class Printer
    {
        static Semaphore sem = new Semaphore(2, 3);
        Thread thread;
        int count = 3;
        public Printer(int i)
        {
            thread = new Thread(Print);
            thread.Name = $"Tasks" + i.ToString();
            thread.Start();
        }
        public void Print()
        {
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} новая задача" );
                Console.WriteLine($"{Thread.CurrentThread.Name} Задача выполняеться!" );
                Thread.Sleep(3000);
                Console.WriteLine($"{Thread.CurrentThread.Name} Задача ВЫПОЛНЕНА!" );

                sem.Release();
                count--;

                Thread.Sleep(1000);
            }
        }

    }
}
