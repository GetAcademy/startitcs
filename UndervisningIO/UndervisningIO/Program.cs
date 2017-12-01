using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace UndervisningIO
{
    class Program
    {
        /*  Input og Output skjerm/tastatur
            Input og Output fil

            Encoding
            using - for å dispose fil-ressurser
            List<string>() - ToArray()
            string.contains
            string.Length
            string.Substring

            Random
         */
        static void Main(string[] args)
        {
            //var path = @"C:\GET IT\C#\UndervisningIO\UndervisningIO\data.txt";
            //var myList = ListFromFile(path);
            //ShowLines(myList);

            //Console.Write("Hei, hva heter du? ");
            //var name = Console.ReadLine();

            //Console.WriteLine("Hei, "
            //    + name.Substring(0, 1).ToUpper()
            //    + name.Substring(1, name.Length - 1).ToLower());

            EncodingTest();
            // 01234 - lengde 5
            // Terje

            //Console.WriteLine("Hei, navnet ditt er " + name.Length + " bokstaver langt!");

            //if (name.ToLower().Contains("er"))
            //{
            //    Console.WriteLine("Navnet ditt inneholder \"er\".");
            //}
        }

        private static void EncodingTest()
        {
            var path = @"C:\GET IT\C#\UndervisningIO\UndervisningIO\data.txt";
            var bytes = File.ReadAllBytes(path);
            foreach (var b in bytes)
            {
                Console.Write((char)b);
            }
        }

        private static void ShowLines(string[] myList)
        {
            for (var index = 0; index < myList.Length; index++)
            {
                var line = myList[index];
                Console.WriteLine(line);
            }
        }

        private static string[] ListFromFile(string path)
        {
            var myList = new List<string>();
            using (var streamReader = File.OpenText(path))
            {
                string line = null;

                do
                {
                    line = streamReader.ReadLine();
                    if (line != null)
                    {
                        myList.Add(line);
                    }
                } while (line != null);
            }
            return myList.ToArray();
        }
    }
}
