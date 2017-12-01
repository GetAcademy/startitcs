using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Place("Stavern", "Larvik", "Vestfold");
            var b = new Place("Stavern", "Larvik", "Vestfold");
            var x = 7;

            if (a == b) Console.WriteLine("A og b er like!");
            else Console.WriteLine("A og b er IKKE like!");

            if (a.PlaceName == b.PlaceName) Console.WriteLine("A.PlaceName og b.PlaceName er like!");
            else Console.WriteLine("A.PlaceName og b.PlaceName er IKKE like!");

            Console.WriteLine("FØR:   a.PlaceName = " + a.PlaceName);
            Console.WriteLine("FØR:   x = " + x);

            DoSomething(a, x);

            Console.WriteLine("ETTER: a.PlaceName = " + a.PlaceName);
            Console.WriteLine("ETTER: x = " + x);
        }

        private static void DoSomething(Place place, int number)
        {
            //place = new Place("Bergen", "Bergen", "Hordaland");
            place.PlaceName = "Bergen";
            number += 9;
        }
    }
}
