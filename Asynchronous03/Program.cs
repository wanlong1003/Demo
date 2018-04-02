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
            var t1 = DownLoad.DownLoad01("https://cdn.mysql.com//Downloads/MySQL-5.7/mysql-5.7.21-winx64.zip");
            var t2 = DownLoad.DownLoad02("https://cdn.mysql.com//Downloads/MySQL-5.7/mysql-5.7.21-winx64.zip");
            Console.WriteLine("开始下载" + DateTime.Now.ToString());
            Task.WaitAll(t1, t2);
            Console.WriteLine("下载完成，t1="+t1.Result +",t2="+t2.Result +"; " +DateTime.Now.ToString());
            Console.ReadLine();
        }
    }
}
