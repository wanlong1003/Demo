using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CallerInfo
{
    class Log
    {
        public static void Debug(string message, [CallerLineNumber] int line = -1, [CallerFilePath] string path=null, [CallerMemberName] string name=null)
        {
                Console.WriteLine(message + (line >=0? "line="+line: "") +( path==null?"":"path="+path)+(name==null?"":"name="+name));
        }
    }
}
