using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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


            List<string> operace = new List<string>();

            List<float> cisla = new List<float>();
            float vysledek = 0;


            while (true)
            {
                Console.WriteLine("zadejte příklad");
                string vypocet = Console.ReadLine();
                List<string> elementy = vypocet.Split(' ').ToList();
                List<string> spatne = new List<string>();
                elementy.Add("_");
                elementy.Add("0");
                if (elementy.Count <= 4)
                {
                    spatne.Add("a");

                }
                 
                for (int i = 0; i < elementy.Count - 2; i++)
                {
                    if (!(float.TryParse(elementy[i], out float cislo1) || elementy[i] == "+" || elementy[i] == "-"))
                    {

                        spatne.Add(elementy[i]);
                    }
                }
                 
                if (spatne.Count == 0)
                {
                    for (int i = 0; i < elementy.Count - 2; i++)
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
                    break;
                }
                
                else
                {

                    Console.WriteLine("příklad byl zadán špatně");
                }
                

                
                
            }
            
                vysledek = cisla[0];
                for (int i = 0; i < operace.Count; i++)
                    switch (operace[i])
                    {
                        case "+":

                            vysledek = vysledek + cisla[i + 1];

                            break;
                        case "-":

                            vysledek = vysledek - cisla[i + 1];


                            break;
                        case "_":

                            break;






                    }

                Console.WriteLine(vysledek);
                Console.ReadKey();













            
        }
    }
}
