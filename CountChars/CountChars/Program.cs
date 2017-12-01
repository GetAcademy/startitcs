using System;

namespace CountChars
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadTextAndShowCharCounts(250);
        }

        private static void ReadTextAndShowCharCounts(int range)
        {            
            string text = "something";
            while (!string.IsNullOrWhiteSpace(text))
            {
                text = Console.ReadLine();
                var counts = CountChars(text, range);
                ShowCounts(range, counts);
            }
        }

        private static void ShowCounts(int range, int[] counts)
        {
            for (var i = 0; i < range; i++)
            {
                if (counts[i] == 0) continue;
                var character = (char) i;
                Console.WriteLine("\"" + character + "\" - " + counts[i]);
            }
        }

        private static int[] CountChars(string text, int range)
        {
            var counts = new int[range];
            foreach (var character in text)
            {
                counts[(int) character]++;
            }
            return counts;
        }
    }
}
