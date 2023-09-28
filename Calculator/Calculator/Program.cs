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

namespace Kalkulačka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Vyberte kalkulačku:");
                Console.WriteLine("1. Jednoduchá kalkulačka");
                Console.WriteLine("2. Kalkulačka pro výrazy");
                
                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        JednoduchaKalkulacka();
                        break;

                    case "2":
                        KalkulackaProVyrazy();
                        break;

                    

                    default:
                        Console.WriteLine("špatně zadaný input");
                        break;
                }
            }
        }

        static void JednoduchaKalkulacka()
        {
            double doubleX = 0.0;
            double doubleY = 0.0;
            string x = "";
            string y = "";
            string odpoved = "";
            double vysledek = 0.0;

            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Zadejte první číslo:");
                    x = Console.ReadLine();
                     
                    Console.WriteLine("Zadejte druhé číslo:");
                    y = Console.ReadLine();
                     

                    if (double.TryParse(x, out doubleX) && double.TryParse(y, out doubleY))
                    {
                        break;
                    }
                    else if (x == "ans" || y == "ans")
                    {

                    }
                    else
                    {
                        Console.WriteLine("příklad zadán špatně");
                    }
                }

                Console.WriteLine("Zadejte operátor");
                string operatorSymbol = Console.ReadLine();

                switch (operatorSymbol)
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

                Console.WriteLine("Výsledek: " + vysledek);
                Console.WriteLine("Chcete pokračovat? ano/ne");
                odpoved = Console.ReadLine();
                if (odpoved == "ne")
                {
                    break;
                }
                
            }
        }

        static void KalkulackaProVyrazy()
        {
            List<string> operace = new List<string>();
            List<float> cisla = new List<float>();
            float vysledek = 0;

            while (true)
            {
                Console.WriteLine("Zadejte příklad např. 1 + 2 - 3 ...");
                string vypocet = Console.ReadLine();
                List<string> elementy = vypocet.Split(' ').ToList();
                List<string> spatne = new List<string>();

                if (elementy.Count <= 2)
                {
                    spatne.Add("a");
                }

                Zkontrolovat(elementy, spatne);

                if (spatne.Count == 0)
                {
                    ZiskatCislaZnaky(elementy);
                    break;
                }
                else
                {
                    Console.WriteLine("příklad zadán špatně");
                }
            }

            Vypocet();

            // Funkce pro kalkulačku pro výrazy
            void Zkontrolovat(List<string> elementy, List<string> spatne)
            {
                for (int i = 0; i < elementy.Count; i++)
                {
                    if (!(float.TryParse(elementy[i], out float cislo1) || elementy[i] == "+" || elementy[i] == "-"))
                    {
                        spatne.Add(elementy[i]);
                    }
                }

                for (int j = 0; j < elementy.Count; j += 2)
                {
                    if (!(float.TryParse(elementy[j], out float cislo1)))
                    {
                        spatne.Add(elementy[j]);
                    }
                }

                for (int k = 1; k < elementy.Count; k += 2)
                {
                    if (!((elementy[k] == "+" || elementy[k] == "-")))
                    {
                        spatne.Add(elementy[k]);
                    }
                }
            }

            void ZiskatCislaZnaky(List<string> elementy)
            {
                for (int i = 0; i < elementy.Count; i++)
                {
                    if (float.TryParse(elementy[i], out float cislo2))
                    {
                        cislo2 = float.Parse(elementy[i]);
                        cisla.Add(cislo2);
                    }
                    else if (elementy[i] == "+" || elementy[i] == "-")
                    {
                        operace.Add(elementy[i]);
                    }
                }
            }

            void Vypocet()
            {
                vysledek = cisla[0];

                for (int i = 0; i < operace.Count; i++)
                {
                    switch (operace[i])
                    {
                        case "+":
                            vysledek = vysledek + cisla[i + 1];
                            break;

                        case "-":
                            vysledek = vysledek - cisla[i + 1];
                            break;
                    }
                }

                Console.WriteLine("Výsledek: " + vysledek);
                Console.ReadKey();
            }
        }
    }
}

