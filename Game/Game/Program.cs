using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] array = BackGround();

            array[0, 0] = "@";
            PrintArray(array);
            Movement(array);
        }
        static string[,] BackGround()
        {
            // Create a 16x16 array of strings initialized with empty spaces
            string[,] array16x16 = new string[16, 16];

            // Initialize each element with a space
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    array16x16[i, j] = ".";
                }
            }

            // Return the array for further use if needed
            return array16x16;
        }

        static void PrintArray(string[,] array)
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static string[,] Movement(string[,] array)
        {
            int positionX = 0;
            int positionY = 0;
            while (true)
            {
                // Wait for a key press
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                Console.WriteLine(keyInfo.Key);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        array[positionX, positionY] = ".";
                        positionY = Math.Min(positionY + 1, array.GetLength(1) - 1);
                        array[positionX, positionY] = "@";
                        break;
                    case ConsoleKey.LeftArrow:
                        array[positionX, positionY] = ".";
                        positionY = Math.Max(positionY - 1, 0);
                        array[positionX, positionY] = "@";
                        break;
                    case ConsoleKey.UpArrow:
                        array[positionX, positionY] = ".";
                        positionX = Math.Max(positionX - 1, 0);
                        array[positionX, positionY] = "@";
                        break;
                    case ConsoleKey.DownArrow:
                        array[positionX, positionY] = ".";
                        positionX = Math.Min(positionX + 1, array.GetLength(0) - 1);
                        array[positionX, positionY] = "@";
                        break;
                    

                    default:
                        // For keys that are not arrows, do nothing
                        break;
                }
                Thread.Sleep(10);
                PrintArray(array);
            }
            return array;
        }
    }
}
