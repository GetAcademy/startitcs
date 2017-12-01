using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace UndervisningExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Exception
             * try - catch
             * throw
             * finally
             *  - NullReferenceException
             *  - DivideByZeroException
             *  - IndexOutOfRangeException
             *  - InvalidCastException
             *  - NotImplementedException
             * Fange spesifikk
             * Fange alle
             * Call stack
             * Egne Exceptions
             */
            DemoInvalidCastException();
            ExceptionsDemoFinally(5, 0);
            ExceptionsDemoFinally(5, 1);
            try
            {
                ExceptionsDemo2();
            }
            catch (TerjeException e)
            {
                Console.WriteLine("TerjeException!");
            }

            try
            {
                ExceptionsDemo1();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Prøvde å dele med 0");
            }

        }

        private static void DemoInvalidCastException()
        {
            object value = 12;
            // Cast throws an InvalidCastException exception.
            string s = (string)value;
        }

        private static int ExceptionsDemoFinally(int n, int d)
        {
            try
            {
                return n / d;
            }
            catch (DivideByZeroException)
            {
                return -1;
            }
            finally
            {
                Console.WriteLine($"Dette gjøres uansett (n={n}, d={d})" );
            }
        }

        private static void ExceptionsDemo2()
        {
            throw new TerjeException();
        }

        private static void ExceptionsDemo1()
        {
            DivideByZero();

            // IndexOutOfRangeException
            var a = new int[10];
            a[20] = 1;

            // NullReferenceException:
            string s = null;
            Console.WriteLine(s.Length);
        }

        private static void DivideByZero()
        {
            // DivideByZeroException
            var i = 0;
            var number = 17 / i;
        }
    }
}
