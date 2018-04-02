using System;
using System.Threading;

namespace Asynchronous01
{
    /// <summary>
    /// 异步模型的Demo
    ///   异步模型指的是定义了BeginXXX和EndXXX方法来实现异步
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //定义一个委托
            Func<string, string> process = name =>
            {
                Thread.Sleep(3000);
                return $"[{DateTime.Now}] 你好,{name}";
            };

            //异步执行委托
            process.BeginInvoke("习近平", (ar) => {
                //异步执行完成后返回
                var result = process.EndInvoke(ar);
                Console.WriteLine($"[{DateTime.Now}] {result}");
            }, null);

            Console.WriteLine($"[{DateTime.Now}] 执行开始...");
            Console.ReadLine();
        }
    }
}
