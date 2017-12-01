using System;

namespace FlexiArray
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * FlexiArray for int
             * Et eksempel på bruk av objekt
             * FlexiArray for alle klasser - Generics
             * 
             * List<string> - List<int>
             */

            int[] x = new int[10];
            x[3] = 7;

            var flexiArray = new FlexiArray();
            flexiArray.Add(3, 7);
            flexiArray.Add(13, 7);
            flexiArray.Add(113, 7);
            flexiArray.Add(161, 7);
            for (var i = 0; i < flexiArray.Length; i++)
            {
                Console.Write(flexiArray.Get(i) + " ");
            }

            var flexiArray2 = new GenericFlexiArray<string>();
            flexiArray2.Add(3, "dsfjlg");
            flexiArray2.Add(13, ",jh");
            flexiArray2.Add(113, "kljh");
            flexiArray2.Add(161, "kjgh");
            for (var i = 0; i < flexiArray2.Length; i++)
            {
                Console.Write(flexiArray2.Get(i) + " ");
            }
        }
    }
}
