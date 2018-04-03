using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallerInfo
{
    /// <summary>
    /// 获取调用者信息
    ///   可以使用这种方法来输出错误发生的位置
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Log.Debug("Main中调用");
            Write();
            Console.ReadLine();
        }

        static void Write()
        {
            Log.Debug("Write中调用");
        }
    }
}
