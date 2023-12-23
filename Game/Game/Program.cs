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
        static bool isMovementInProgress = false;
        static void Main(string[] args)
        {
            string[,] array = BackGround();

            array[0, 0] = "@";
            PrintArray(array);
            Movement(array);
            

        }
        static string[,] Maze()
        {
            string[,] array = new string[16, 16];
            return array;
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
            array16x16[2, 2] = "#";
            // Return the array for further use 
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
        static void Movement(string[,] array)
        {
            int positionX = 0;
            int positionY = 0;

            //stolen from chatgpt but I sort of get what it does
            //creates variable with the smallest possible value of DateTime, just to initialise it
            DateTime pressTime = DateTime.MinValue;
            //creates variable cooldown with the value of 50 milliseconds
            TimeSpan cooldown = TimeSpan.FromMilliseconds(50);
            
            while (true)
            {
             
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Console.WriteLine(pressTime);
                    

                    // Check if enough time(at least 50 milliseconds) has passed since the last key press
                    if ((DateTime.Now - pressTime) >= cooldown)
                    {
                        Console.Clear();
                        Console.WriteLine(keyInfo.Key);
                        
                        // Store the current position for reverting changes if needed
                        int previousX = positionX;
                        int previousY = positionY;

                        // Handle movement based on the pressed key
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.RightArrow:
                                if (array[positionX, positionY + 1] != "#") 
                                {
                                    array[positionX, positionY] = ".";
                                    positionY++;
                                    array[positionX, positionY] = "@";
                                }
                                break;
                                
                            case ConsoleKey.LeftArrow:
                                if (array[positionX, positionY - 1] != "#")
                                {
                                    array[positionX, positionY] = ".";
                                    positionY--;
                                    array[positionX, positionY] = "@";
                                }
                                break;
                            case ConsoleKey.UpArrow:
                                if (array[positionX - 1, positionY] != "#")
                                {
                                    array[positionX, positionY] = ".";
                                    positionX--;
                                    array[positionX, positionY] = "@";
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (array[positionX + 1, positionY] != "#")
                                {
                                    array[positionX, positionY] = ".";
                                    positionX++;
                                    array[positionX, positionY] = "@";
                                }
                                break;

                            default:
                                // For keys that are not arrows, does nothing for now
                                break;
                        }

                        PrintArray(array);

                        //changes the pressTime variable to current time when the key was pressed
                        pressTime = DateTime.Now;
                    }
                }
            }
        }
    }
}
/*
 *################
 *#              #
 *#              #
 *#              #
 *#              #
 *#              #
 *#              #
 *################
 */