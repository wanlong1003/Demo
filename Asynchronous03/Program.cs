using System;
using System.Net;
using System.Threading.Tasks;

namespace Asynchronous03
{
    /// <summary>
    /// 基于任务的异步模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = DownLoad.DownLoad01("https://dldir1.qq.com/qqfile/qq/TIM2.1.5/23141/TIM2.1.5.exe");
            //表示t1异步完成后的回调方法
            t1.ContinueWith(t => Console.WriteLine("t1 Complated:"+t.Result));

            var t2 = DownLoad.DownLoad02("https://dldir1.qq.com/qqfile/qq/TIM2.1.5/23141/TIM2.1.5.exe");
            t2.ContinueWith(t => Console.WriteLine(t.Result));

            Console.WriteLine("开始下载" + DateTime.Now.ToString());
            Task.WaitAll(t1, t2);
            Console.WriteLine("下载完成，t1="+t1.Result +",t2="+t2.Result +"; " +DateTime.Now.ToString());
            Console.ReadLine();
        }
    }
}
