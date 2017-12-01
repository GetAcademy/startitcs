using System;
using System.Linq;

namespace PasswordGenerator
{
    class Program
    {
        static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            if (!IsValid(args))
            {
                ShowHelpText();
                return;
            }
            var length = Convert.ToInt32(args[0]);
            var options = args[1];

            var pattern = options.PadRight(length, 'l');
            // StringBuffer
            var password = string.Empty;
            while (pattern.Length > 0)
            {
                var randomIndex = Random.Next(0, pattern.Length - 1);
                var category = pattern[randomIndex];

                /* remove selected character
                   example:    01234567
                               abcdefgh
                               selected = d (randomIndex=3)
                               length = 8
                               we want "abc" + "efgh"
                               */
                pattern = pattern.Substring(0, randomIndex)
                        + pattern.Substring(randomIndex + 1, pattern.Length - randomIndex - 1);

                if (category == 'l') password += GetRandomLowerCaseLetter();
                else if(category == 'L') password += GetRandomUpperCaseLetter();
                else if(category == 'd') password += GetRandomDigit();
                else  password += GetRandomSpecialCharacter();
            }
            Console.WriteLine(password);
        }

        private static char GetRandomSpecialCharacter()
        {
            var allSpecialCharacters = "!\"#¤%&/(){}[]";
            var index = Random.Next(0, allSpecialCharacters.Length-1);
            return allSpecialCharacters[index];
        }

        private static char GetRandomDigit()
        {
            return Random.Next(0, 9).ToString()[0];
        }

        private static char GetRandomUpperCaseLetter()
        {
            return GetRandomLetter('A', 'Z');
        }

        private static char GetRandomLowerCaseLetter()
        {
            return GetRandomLetter('a', 'z');
        }

        private static char GetRandomLetter(char min, char max)
        {
            return (char)Random.Next(min, max);
        }

        private static bool IsValid(string[] args)
        {
            if (args.Length != 2) return false;

            var lengthStr = args[0];
            var options = args[1];

            //foreach (var character in options)
            //{
            //    if (character != 'l'
            //        && character != 'L'
            //        && character != 'd'
            //        && character != 's')
            //    {
            //        return false;
            //    }
            //}
            if (options.Any(character => character != 'l'
                                         && character != 'L'
                                         && character != 'd'
                                         && character != 's'))
            {
                return false;
            }

            //foreach (var character in lengthStr)
            //{
            //    if (!char.IsDigit(character))
            //    {
            //        return false;
            //    }
            //}
            //return true;
            return lengthStr.All(char.IsDigit);
        }

        private static void ShowHelpText()
        {
            Console.WriteLine("PasswordGenerator <length> <options>");
            Console.WriteLine("  Options:");
            Console.WriteLine("  - l = lower case letter");
            Console.WriteLine("  - L = upper case letter");
            Console.WriteLine("  - d = digit");
            Console.WriteLine("  - s = special character (!\"#¤%&/(){}[]");
            Console.WriteLine("Example: PasswordGenerator 14 lLssdd");
            Console.WriteLine("         Min. 1 lower case");
            Console.WriteLine("         Min. 1 upper case");
            Console.WriteLine("         Min. 2 special characters");
            Console.WriteLine("         Min. 2 digits");
        }
    }
}
