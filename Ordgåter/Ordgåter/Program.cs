using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;

namespace Ordgåter
{
    class Program
    {
        private static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            // Velge tilfeldig ord.  - eks: abonnement
            var words = GetWords();
            var wordCount = 200;
            while (wordCount > 0)
            {
                var hasFoundMatch = FindWordProblem(words);
                if (hasFoundMatch) wordCount--;
            }
        }

        private static bool FindWordProblem(string[] words)
        {
            var randomWordIndex = Random.Next(words.Length);
            var selectedWord = words[randomWordIndex];
            Console.Write(selectedWord + " - ");

            // Leter videre etter ord som begynner på siste del av dette ordet. - mental
            foreach (var word in words)
            {
                if (!IsLastPartOfFirstWordEqualToFirstPartOfSecondWord(selectedWord, word)) continue;
                Console.WriteLine(word);
                return true;
            }
            Console.WriteLine("<fant ikke match>");
            return false;
        }

        private static bool IsLastPartOfFirstWordEqualToFirstPartOfSecondWord(string word1, string word2)
        {
            return IsLastPartOfFirstWordEqualToFirstPartOfSecondWord(4, word1, word2)
            || IsLastPartOfFirstWordEqualToFirstPartOfSecondWord(5, word1, word2);
        }

        private static bool IsLastPartOfFirstWordEqualToFirstPartOfSecondWord(int commonLength, string word1, string word2)
        {
            // 0123456789
            // abonnement - commonLength == 4
            // "abonnement".Length == 10
            var lastPartOfFirstWord = word1.Substring(word1.Length - commonLength, commonLength);
            // 012345
            // mental
            var firstPartOfSecondWord = word2.Substring(0, commonLength);

            return lastPartOfFirstWord == firstPartOfSecondWord;
        }

        static string[] GetWords()
        {
            var lastWord = string.Empty;
            var filePath = @"C:\GET IT\C#\Ordgåter\Ordgåter\ordliste.txt";
            var wordList = new List<string>();
            foreach (var line in File.ReadLines(filePath, Encoding.UTF8))
            {
                var parts = line.Split('\t');
                var word = parts[1];
                if (word != lastWord
                    && word.Length > 6
                    && word.Length < 10
                    && !word.Contains("-"))
                {
                    wordList.Add(word);
                }
                lastWord = word;
            }
            return wordList.ToArray();
        }
    }
}