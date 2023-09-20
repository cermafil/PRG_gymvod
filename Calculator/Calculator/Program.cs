using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {

        static void Main(string[] args)
        {

            double doubleX = 0.0;
            double doubleY = 0.0;
            string x = "";
            string y = "";
            string odpoved = "";
            int pocitadlo = 0;
            double vysledek = 0.0;

            while (true)
            {
                string vyssledek = Convert.ToString(vysledek);
                pocitadlo++;
                while (true)
                {
                    if (pocitadlo == 1)
                    {
                        Console.WriteLine("Zadejte první číslo");
                        x = Console.ReadLine();
                    }
                    else
                    {
                        x = vyssledek;
                    }
                    Console.WriteLine("první číslo: " + x);
                    Console.WriteLine("Zadejte druhé číslo");
                    y = Console.ReadLine();
                    Console.WriteLine("druhé číslo: " + y);
                    if (double.TryParse(x, out doubleX) && double.TryParse(y, out doubleY))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("zadána nečíslená hodnota lol");
                    }

                }
                double.Parse(x);
                double.Parse(y);

                Console.WriteLine("zadejte operátor");
                string operátor = Console.ReadLine();
                switch (operátor)
                {

                    case "+":
                        vysledek = doubleX + doubleY;
                        break;

                    case "-":
                        vysledek = doubleX - doubleY;
                        break;
                    case "*":
                        vysledek = doubleX * doubleY;
                        break;
                    case "/":
                        vysledek = (doubleX / doubleY);
                        break;
                }
                Console.WriteLine("vysledek: " + vysledek);

                Console.WriteLine("chcete dále počítat? ano/ne ");
                odpoved = Console.ReadLine();
                if (odpoved == "ne")
                {
                    break;
                }



                Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.

            }
        }
    }
}
