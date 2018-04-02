using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous03
{
    class DownLoad
    {
        static int percentage = 0;
        public static async Task<int> DownLoad01(string url)
        {
            using (var client = new WebClient())
            {
                //添加下载进度
                client.DownloadProgressChanged += (sender, e) =>
                {
                    if (percentage < e.ProgressPercentage)
                    {
                        Console.WriteLine($"[{DateTime.Now.ToString()}] {e.BytesReceived/1024}kB/{e.TotalBytesToReceive/1024}kB : {e.ProgressPercentage}%");
                        percentage = e.ProgressPercentage;
                    }

                };
                //第一种异步下载方式
                var buffer = await client.DownloadDataTaskAsync(url);
                return buffer.Length;
            }
        }

        public static async Task<int> DownLoad02(string url)
        {
            //第二种异步下载方式
            var task = await Task.Run(() =>
             {
                 using (var client = new WebClient())
                 {
                     var buffer = client.DownloadData(url);
                     return buffer.Length;
                 }
             });
            return task;

        }
    }
}
