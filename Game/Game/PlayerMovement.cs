using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class PlayerMovement
    {
        public int positionX;
        public int positionY;
        

        public PlayerMovement(int startX, int startY)
        {
            positionX = startX;
            positionY = startY;

        }
        public static void Movement(Background background)
        {
            int positionX = 1;
            int positionY = 1;
            string[,] array = background.Array;
            //stolen from chatgpt but I sort of get what it does
            //creates variable with the smallest possible value of DateTime, just to initialise it
            DateTime pressTime = DateTime.MinValue;
            //creates variable cooldown with the value of 50 milliseconds
            TimeSpan cooldown = TimeSpan.FromMilliseconds(50);
            List<Background> map = Background.MakeMap(background);
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    


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

                        Background.PrintArray(array);

                        //changes the pressTime variable to current time when the key was pressed
                        pressTime = DateTime.Now;
                    }
                }
                if (positionY == array.GetLength(1) - 1 || positionY == 0 || positionX == array.GetLength(0) - 1 || positionX == 0)
                {
                    
                    Movement(map[1]);
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
