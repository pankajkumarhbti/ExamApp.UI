using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG

            Console.Write(" Pankaj");
#endif
            Console.Write("\n Puneet");

            Console.Read();
        }
    }
}
