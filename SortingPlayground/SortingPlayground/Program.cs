using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace SortingPlayground
{
    internal class Program
    {
        //Pokud si nejsi jistý/á, co dělat, podívej se do prezentace, na videa na YT, co jsem doporučoval, googluj a nebo mě zavolej a já ti poradím.

        static int[] BubbleSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            int x = 0;
            int counter =0 ;
            for (int j = 0; j < array.Length; j++)
            {
                
                for (int i = 0; i < sortedArray.Length - 1; i++)
                {
                    
                    if (sortedArray[i] > sortedArray[i + 1])
                    {
                        x = sortedArray[i + 1];
                        sortedArray[i + 1] = sortedArray[i];
                        sortedArray[i] = x;

                        counter++;
                    }
                    

                }
                
            }
            Console.WriteLine(counter);
            return sortedArray;
        }
        static int[] SelectionSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            int placeholder = 0;
            int min = sortedArray[0];
            int counter = 0;
            for (int i = 0; i < sortedArray.Length - 1; i++)
            {

                for (int k = i; k < sortedArray.Length; k++)
                {
                    
                    if (min < sortedArray[k])
                    {
                        min = sortedArray[k];
                        counter = k;
                        placeholder = sortedArray[i];
                        sortedArray[i] = min;
                        sortedArray[counter] = placeholder;
                    }
                    
                }
                min = sortedArray[i + 1];
            }
            Array.Reverse(sortedArray);
            return sortedArray;
        }

        static int[] InsertionSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            int placeholder = 0;
            for(int i = 1;i < sortedArray.Length ;i++)
            {
                placeholder = sortedArray[i];
                int j = i - 1;
                while(j >= 0 && placeholder < sortedArray[j])
                {
                    sortedArray[j+1] = sortedArray[j];
                    j = j - 1;

                }
                sortedArray[j+1] = placeholder;
            }
            return sortedArray;
        }

        //Naplní pole náhodnými čísly mezi 1 a velikostí pole.
        static void FillArray(int[] array)
        {
            Random rng = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rng.Next(1, array.Length + 1);
            }
        }

        //Vypíše pole do konzole.
        static void WriteArrayToConsole(int[] array, string arrayName)
        {
            Console.Write(arrayName + " = [");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]\n\n");
        }

        //Zavolá postupně Bubble sort, Selection sort a Insertion sort pro zadané pole (a vypíše jeho jméno pro přehlednost)
        static void SortArray(int[] array, string arrayName)
        {
            Console.WriteLine($"Řadím {arrayName}:");
            int[] sortedArray;

            sortedArray = BubbleSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Bubble sortem");

            sortedArray = SelectionSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Selection sortem");

            sortedArray = InsertionSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Insertion sortem");

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] smallArray = new int[10];
            FillArray(smallArray);

            int[] mediumArray = new int[100];
            FillArray(mediumArray);

            int[] largeArray = new int[1000];
            FillArray(largeArray);

            WriteArrayToConsole(smallArray, "Malé pole");
            SortArray(smallArray, "Malé pole");

            WriteArrayToConsole(mediumArray, "Střední pole");
            SortArray(mediumArray, "Střední pole");

            //WriteArrayToConsole(largeArray, "Velké pole");
            //SortArray(largeArray, "Velké pole");

            Console.ReadKey();
        }
    }
}
