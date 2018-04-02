using System;
using System.Net;

namespace Asynchronous02
{
    /// <summary>
    /// 基于事件的异步模型
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            var lockObj = new object();
            using (var client = new WebClient())
            {
                //定义下载完成回调
                client.DownloadDataCompleted += (sender, e) =>
                {
                    Console.WriteLine($"[{DateTime.Now}] 下载完成，本次下载了 {e.Result.Length} 个字节");
                };
                //定义进度百分比
                client.DownloadProgressChanged += (sender, e) =>
                {
                    lock (lockObj)
                    {
                        if (e.ProgressPercentage > count)
                        {
                            var width = Console.LargestWindowWidth - 7;  //Console.LargestWindowWidth有问题
                            var message = "";
                            message = message.PadRight((width * e.ProgressPercentage) / 100, '=');
                            message = message.PadRight(width);
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write($"{message}[{e.ProgressPercentage.ToString().PadLeft(3)}%]");
                            count = e.ProgressPercentage;
                        }
                    }

                };

                //开始下载
                var url = "https://cdn.mysql.com//Downloads/MySQL-5.7/mysql-5.7.21-winx64.zip";
                Console.WriteLine("开始下载MySQL程序包...");
                client.DownloadDataAsync(new Uri(url));
            }

            Console.ReadLine();
        }
    }
}
