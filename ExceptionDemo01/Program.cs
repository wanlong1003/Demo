using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NoTryCatch();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                TryCatch();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }

        static void NoTryCatch()
        {
            var i = 0;
            var j = 1;
            var r = j / i;
        }

        static void TryCatch()
        {
            try
            {
                var i = 0;
                var j = 1;
                var r = j / i;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
