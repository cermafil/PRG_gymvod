using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace RecursionPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // Nacteme cislo n, pro ktere budeme pocitat jeho faktorial a n-ty prvek Fibonacciho posloupnosti.
            int factorial = Factorial(n); // Prvni zavolani pro vypocet faktorialu, ulozeni do promenne factorial.
            int fibonacci = Fibonacci(n); // Prvni zavolani pro vypocet Fibonacciho posloupnosti, ulozeni do promenne fibonacci.

            Console.WriteLine($"Pro cislo {n} je faktorial {factorial} a {n}. prvek Fibonacciho posloupnosti je {fibonacci}"); // Vypsani vysledku uzivateli.
            Console.ReadKey();
        }

        static int Factorial(int n)
        {
            int factorial = n;
            if (n == 1)
            {

                return factorial;
            }

            factorial *= Factorial(n - 1);
            return factorial;
        }
        static int Fibonacci(int n)
        {

            if (n == 1)
            {
                return 1;
            }
            else if (n == 0)
            {
                return 0;
            }
            int factorial1 = Fibonacci(n - 1);
            int factorial2 = Fibonacci(n - 2);
            return factorial1 + factorial2;

        }
    }
}
