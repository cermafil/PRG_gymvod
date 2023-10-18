﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //TODO 1: Vytvoř integerové pole a naplň ho pěti čísly.

            int[] myArray = { 1, 2, 3, 4, 5 };
            //TODO 2: Vypiš do konzole všechny prvky pole, zkus klasický for, kde i využiješ jako index v poli, a foreach (vysvětlíme si).
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }
             
            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
                sum = sum + myArray[i];
            }
            Console.WriteLine(sum);
            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            int average = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
                average = average + myArray[i];
            }
            average = average / myArray.Length;
            Console.WriteLine(average);

            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
                
                if (myArray[i] > max) 
                {
                    max = myArray[i];
                }
            }
            Console.WriteLine(max);
            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = max;
            
            for (int i = 0; i < myArray.Length; i++)
            {

                if (myArray[i] < min)
                {
                    min = myArray[i];
                }
            }
            Console.WriteLine(min);

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            string input = Console.ReadLine();
            int index = int.Parse(input);
             
            for (int i = 0; i < myArray.Length; i++)
            {

                if (myArray[i] == index)
                {
                    Console.WriteLine(i);
                }
            }
            
            //TODO 8: Změň tvorbu integerového pole tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9. Vytvoř si na to proměnnou typu Random.
            int[] rand = new int[100];
            Random cislo = new Random();
            for (int i = 0; i < 100; i++)
            {
                rand[i] = cislo.Next(0, 10);
            }
            for (int i = 0; i <  rand.Length; i++)
            {
                Console.WriteLine(rand[i]);
            }
            
            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            for(int i = 0; i < rand.Length; i++) 
            {
                int j = rand[i]; 
                counts[j] += 1; 
                

            }
            for (int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine(counts[i]);
            }
            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            Array.Reverse(myArray);
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }

            Console.ReadKey();
        }
    }
}
