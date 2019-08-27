using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab16
{
    class Program
    {

        static Task<int> FactorialAsync(int x)
        {
            int result = 1;
            return Task.Run(() =>
            {
                for (int i = 1; i <= x; i++)
                    result *= i;
                return result;
            });
        }
        static async Task DisplayResultAsync()
        {
            int result = await FactorialAsync(25);//await-нужен чтобы приостановить выполнение метода до тех пор,пока эта задача не завершится
            Thread.Sleep(3);
            Console.WriteLine("Факториал числа {0} равен {1}", 25, result);
        }
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        static CancellationToken token = cancelTokenSource.Token;
        static void Main(string[] args)
        {

            Tasker.GetTask(1000000, 1);
            Tasker.GetTask(1000000, 2);
            Tasker.GetTask(1000000, 3);
            Task task = new Task(() =>
            {
                Tasker.GetTask(100000, 64);
                if (token.IsCancellationRequested)
                    return;
            });
            Tasker.FourSum(new Vector(100), new Vector(20), new Vector(30)).GetAwaiter().GetResult();
            Paralleler.For();
            Paralleler.ForEach();
            Paralleler.DoubleTask(100000);
            Store.Work();
            Task t = DisplayResultAsync();
            t.Wait();
        }
    }
}