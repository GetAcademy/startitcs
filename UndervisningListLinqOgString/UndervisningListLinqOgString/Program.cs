using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UndervisningListLinqOgString
{
    class Program
    {
        static void Main(string[] args)
        {
            /* List<>
             * LINQ
             * string metoder: 
             *   Split
             *   Trim
             *   Vise alle
             */

            DemoString();

            //DemoLINQ();

            //DemoList2();
            //DemoList1();
        }

        private static void DemoString()
        {
            var text = "xxxxxxxTerjexxx;x59xxx;xx63x;jax;xgrønn";
            var parts = text.Split(';');
            foreach (var part in parts)
            {
                Console.WriteLine(part.Trim('x'));
            }
        }

        private static void DemoLINQ()
        {
            var list = GetPoints();
            //var point = list.FirstOrDefault(p => p.X == p.Y);
            //Console.WriteLine(point?.ToString() ?? "null");

            var points = list.Where(p => p.X == p.Y);
            foreach (var p in points)
            {
                Console.WriteLine(p);
            }
            //if(list.Any(p => p.X == p.Y)) { }
            //if(list.All(p => p.X == p.Y)) { }
        }

        private static void DemoList1()
        {
            //int[] list = new int[10];
            var list = new List<int>();
            var random = new Random();
            var count = 0;
            while (true)
            {
                var number = random.Next(0, 100);
                list.Add(number);
                count++;
                if (random.Next(0, 5) == 5) break;
            }

            for (var i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

            list[0] = 9;

            foreach (int number in list)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
        private static void DemoList2()
        {
            var list = GetPoints();

            foreach (var point in list)
            {
                Console.Write(point + " ");
            }
            Console.WriteLine();
        }

        private static List<Point> GetPoints()
        {
            var list = new List<Point>();
            var random = new Random();
            var count = 0;
            while (true)
            {
                var point = new Point(random.Next(0, 10), random.Next(0, 10));
                list.Add(point);
                count++;
                if (random.Next(0, 10) == 5) break;
            }
            return list;
        }
    }
}
