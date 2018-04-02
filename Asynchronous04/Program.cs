using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous04
{
    /// <summary>
    /// 异步模式转任务模式的Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (var socket = new Socket(SocketType.Stream, ProtocolType.Tcp))
            {
                AsyncCallback callBack = arParam => Console.WriteLine(DateTime.Now);
                IAsyncResult begin = socket.BeginConnect("baidu.com", 80, ar => Console.WriteLine("异步完成1" + ar.IsCompleted), null);
                var task = Task.Factory.FromAsync<int>(begin, ar => {Console.WriteLine("异步完成2"+ar.IsCompleted); return 0;  });
                Console.WriteLine("启动异步11");
                Task.WaitAll(task);
                Console.WriteLine("启动异步");
                Console.ReadLine();
            }

        }
    }

    delegate IAsyncResult BeginConnect(string host, int port, AsyncCallback requestCallback, object state);
    delegate void EndConnect(IAsyncResult asyncResult);
}
