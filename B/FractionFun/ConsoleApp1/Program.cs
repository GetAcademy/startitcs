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
            for (var a = 1.0; a < 10000; a++)
                for (var b = 1.0; b < 10000; b++)
                    for (var c = 1.0; c < 10000; c++)
                    {
                        var result = a / (b + c) + b / (a + c) + c / (a + b) - 4;
                        if (Math.Abs(result) < 0.00001) Console.WriteLine(a + " - " + b + " - " + c + "- " + result);
                    }
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
