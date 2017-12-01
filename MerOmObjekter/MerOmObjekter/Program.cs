using System;

namespace MerOmObjekter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo1();
            //Demo2();
            //DemoString();
            DemoSideEffects();
        }

        private static void DemoSideEffects()
        {
            var box = new Box { Width = 20, Height = 30 };
            int i = 7;

            Console.WriteLine("FØR:   i="+i);
            Console.WriteLine("FØR:   box.Height=" + box.Height);

            DoSomething(box, i);

            Console.WriteLine("ETTER: i=" + i);
            Console.WriteLine("ETTER: box.Height=" + box.Height);
        }

        private static void DoSomething(Box b, int i)
        {
            i += 10;
            //b.Height += 10;
            b = new Box() {Width = -1, Height = -1};
        }

        private static void DemoString()
        {
            // string Immutable C#
            // ctring Interning C#
            string a = "Atomabsorpsjonsspektrofotometeranalysemetodikkproblematikken";
            string b = "Atomabsorpsjonsspektrofotometeranalysemetodikkproblematikken";
            if (a == b) Console.WriteLine("A og b er like");
            else Console.WriteLine("A og b er IKKE like");
        }

        private static void Demo2()
        {
            var a = new Box { Width = 20, Height = 30 };
            var b = new Box { Width = 20, Height = 30 };

            if (a == b) Console.WriteLine("A og b er like");
            else Console.WriteLine("A og b er IKKE like");

            if (a.Height == b.Height) Console.WriteLine("A.Height og b.Height er like");
            else Console.WriteLine("A.Height og b.Height er IKKE like");
        }

        private static void Demo1()
        {
            /* Reference types
             *  - objekter
             *  vs
             * Values types
             *  - int, float, bool, double, char
             */
            var a = new Box { Width = 20, Height = 30 };
            var b = new Box { Width = 5, Height = 7 };

            var c = a;
            c.Height = 99;
            Console.WriteLine(a.Height);
        }

        private static void Demo3()
        {
            var a = new Box { Width = 20, Height = 30 };
            var b = new Box { Width = 5, Height = 7 };

            a = b;
        }
    }
}
