using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous05
{
    class Program
    {
        /// <summary>
        /// 任务取消
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //定义一个取消任务的操作对象
            var cts = new CancellationTokenSource();
            Begin(cts);
            Console.WriteLine("任务已启动");
            while (true)
            {
                Console.Write("输入exit结束任务：");
                var key = Console.ReadLine();
                if (string.Compare(key, "exit", true) == 0)
                {
                    cts.Cancel();
                }
            }
        }

        public static async void Begin(CancellationTokenSource cts)
        {
            //捕获任务被终止的时抛出的异常
            try
            {
                await Execute(cts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task Execute(CancellationTokenSource cts)
        {
            while (true)
            {
                //判断任务是否被取消，如果取消则抛出异常
                cts.Token.ThrowIfCancellationRequested();
                Console.WriteLine("执行循环任务啦");
                await Task.Delay(5000);
            }
        }
    }
}
