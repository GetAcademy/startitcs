using System;

namespace UndervisningIntroCS
{
    class Program
    {
        /* To hovedting inne i en klasse:
         *    Felt - tilsvarer (nesten) Javascript globale variable
         *    Metoder - tilsvarer funksjon i Javascript
         * 
         * Pensum idag:
         *    C# er et sterkt typet programmeringsspråk
         *    Intro til Visual Studio
         *    Debugging
         *    Grunnskelettet i en class
         *    Variabler, tilordning, deklarasjon (inkl. var) og datatyper
         *       bool - boolean (true/false)
         *       int - heltall
         *       float/double - desimaltall
         *       string - tekst
         *    Valgsetning
         *    Løkker - for og while som i Javascript - foreach (for tabeller)
         *    Tabeller
         *    Metoder (funksjoner)
         *    Input og output
         */
        static void Main(string[] args)
        {
            // Deklarere en variabel av hver av de nevnte datatypene
            bool b;
            int i;
            float f;
            double d;
            string s;

            // Tilordning
            b = true;
            i = 5;
            f = 3.2f;
            d = 1.2;
            s = "flkjdhg";

            // Kan også deklarere og tilornde samtidig
            bool b2 = false;
            int i2 = 3;
            float f2 = 1.3f;
            double d2 = 7.7;
            string s2 = "kjh";

            var b3 = false;
            var i3 = 9;
            var f3 = 5.5f;
            var d3 = 9.9;
            var s3 = "kjh";


            //if (args.Length == 0)
            //{
            //    Console.WriteLine("Hallo! Ingen parametre. ");
            //}
            //else
            //{
            //    Console.WriteLine("Hallo! Antall parametre: " + args.Length);
            //}

            //foreach (var text in args)
            //{
            //    Console.WriteLine("Parameter: " + text);
            //}
        }
    }
}
