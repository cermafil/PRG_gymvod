using System;
using System.Collections.Generic;
using System.IO;
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
        private static float vysledek = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Vyberte kalkulačku:");
                Console.WriteLine("1. Jednoduchá kalkulačka");
                Console.WriteLine("2. Kalkulačka pro výrazy");
                Console.WriteLine("3. převaděč do binární soustavy");
                
                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        JednoduchaKalkulacka();
                        break;

                    case "2":
                        KalkulackaProVyrazy();
                        break;

                    case "3":
                        binarni();
                        break;
                    default:
                        Console.WriteLine("špatně zadaný input");
                        break;
                }
            }
        }
        static void binarni()
        {
            Console.WriteLine("Vyberte kalkulačku:");
            Console.WriteLine("1. Decimální soustava --> Binární soustava");
            Console.WriteLine("2. Binární soustava --> Decimální soustava");

            string volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    while (true)
                    {
                       
                        Console.WriteLine("Zadejte celé číslo:");
                        string input = Console.ReadLine();
                        if (JeValidní(input))
                            {
                            int cislo = int.Parse(input);
                            DecimálníNaBinární(cislo);
                            break;
                        }
                        
                    }
                    break;

                case "2":
                    BinárníNaDesitkovou();
                    break;

                default:
                    Console.WriteLine("Špatně zadaný vstup.");
                    break;
            }
        }
        static bool JeValidní(string input)
        {
            if (int.TryParse(input, out int cislo))
            {
                return true;
            }
            else
            {
                
                foreach (char c in input)
                {
                    if (c != '0' && c != '1')
                    {
                        return false;
                    }
                }
                return true;
            }
        }


        static void DecimálníNaBinární(int cislo)
        {
           
            List<string> zbytky = new List<string>();

            while (cislo > 0)
            {
                if (cislo % 2 == 0)
                {
                    zbytky.Add("0");
                }
                else
                {
                    zbytky.Add("1");
                }
            cislo = cislo / 2;
            }
                    zbytky.Reverse();
        Console.WriteLine("Výsledek je: " + string.Join("", zbytky));
                    
                
            
        }

        static void BinárníNaDesitkovou()
        {
            Console.WriteLine("Zadejte binární číslo:");
            while (true)
            {
                string input = Console.ReadLine();
                int cislo = 0;
                int pozice = 0;
                bool jePlatny = true;

                foreach (char c in input)
                {
                    if (c != '0' && c != '1')
                    {
                        jePlatny = false;
                        break;
                    }
                }

                if (jePlatny)
                {
                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        if (input[i] == '1')
                        {
                            cislo += (int)Math.Pow(2, pozice);
                        }
                        pozice++;
                    }

                    Console.WriteLine("Výsledek je: " + cislo);
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatný binární vstup. Zadejte pouze 0 a 1.");
                }
            }
        }
        static void JednoduchaKalkulacka()
        {
            float cislo1 = 0;
            float cislo2 = 0;
            string input1;
            string input2;
            string odpoved = "";
            

            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Zadejte první číslo:");
                    input1 = Console.ReadLine();
                     
                    Console.WriteLine("Zadejte druhé číslo:");
                    input2 = Console.ReadLine();


                    if (float.TryParse(input1, out cislo1) && float.TryParse(input2, out cislo2))
                    {
                        break;
                    }
                    else if (input1 == "ans")
                    {
                        cislo1 = vysledek;
                        break;
                    }
                    else if (input2 == "ans")
                    {
                        cislo2 = vysledek;
                        break;
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
                        vysledek = cislo1 + cislo2;
                        break;

                    case "-":
                        vysledek = cislo1 - cislo2;
                        break;
                    case "*":
                        vysledek = cislo1 * cislo2;
                        break;
                    case "/":
                        vysledek = (cislo1 / cislo2);
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

            void Zkontrolovat(List<string> elementy, List<string> spatne)
            {
                for (int i = 0; i < elementy.Count; i++)
                {
                    if (!(float.TryParse(elementy[i], out float cislo1) || elementy[i] == "+" || elementy[i] == "-" || elementy[i] == "*" || elementy[i] == "/" || elementy[i] == "ans"))
                    {
                        spatne.Add(elementy[i]);
                    }
                }

                for (int j = 0; j < elementy.Count; j += 2)
                {
                    if (!(float.TryParse(elementy[j], out float cislo1) || elementy[j] == "ans"))
                    {
                        spatne.Add(elementy[j]);
                    }
                }

                for (int k = 1; k < elementy.Count; k += 2)
                {
                    if (!((elementy[k] == "+" || elementy[k] == "-" || elementy[k] == "*" || elementy[k] == "/" || elementy[k] == "ans")))
                    {
                        spatne.Add(elementy[k]);
                    }
                }
            }

            void ZiskatCislaZnaky(List<string> elementy)
            {
                for (int i = 0; i < elementy.Count; i++)
                {
                    if (float.TryParse(elementy[i], out float cislo2) || elementy[i] == "ans")
                    {
                        if (elementy[i] == "ans")
                        {
                            cisla.Add(vysledek); 
                        }
                        else
                        {
                            cislo2 = float.Parse(elementy[i]);
                            cisla.Add(cislo2);
                        }
                    }
                    else if (elementy[i] == "+" || elementy[i] == "-" || elementy[i] == "*" || elementy[i] == "/")
                    {
                        operace.Add(elementy[i]);
                    }
                }
            }

            void Vypocet()
            {
                for (int i = 0; i < operace.Count; i++)
                {
                    if (operace[i] == "*")
                    {
                        cisla[i] = cisla[i] * cisla[i + 1];
                        cisla[i + 1] = 0;
                    }
                    else if (operace[i] == "/")
                    {
                        cisla[i] = cisla[i] / cisla[i + 1];
                        cisla[i + 1] = 0;
                    }
                }
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
    


