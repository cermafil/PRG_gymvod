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
        public static int i = 0;
        public static Background start = new Background(0, 4);
        public static List<Background> map = Background.MakeMap(start);
        public static void Movement(Background background, int positionX, int positionY)
        {
            
            string[,] array = background.Array;
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
                    


                    // Check if enough time(at least 50 milliseconds) has passed since the last key press
                    if ((DateTime.Now - pressTime) >= cooldown)
                    {
                        Console.Clear();
                        
                        
                        // Store the current position for reverting changes if needed
                        int previousX = positionX;
                        int previousY = positionY;
                        if (positionY == array.GetLength(1) - 1 || positionY == 0 || positionX == array.GetLength(0) - 1 || positionX == 0)
                        {
                            

                            if (positionY == array.GetLength(1) - 1 && map[i].NextDoorPosition == 4)
                            {
                                
                                i++;
                                Console.WriteLine(i);
                                positionX = map[i].Array.GetLength(0) / 2;
                                positionY = 1;
                                map[i].Array[map[i].Array.GetLength(0) / 2, 0] = ".";
                                Movement(map[i], positionX, positionY);

                            }

                            else if (positionY == array.GetLength(1) - 1 && map[i].BackDoorPosition == 4)
                            {
                                i--;

                                Console.WriteLine(i);
                                positionX = map[i].Array.GetLength(0) / 2;
                                positionY = 1;
                                map[i].Array[map[i].Array.GetLength(0) / 2, 0] = ".";
                                Movement(map[i], positionX, positionY);
                            }
                            else if (positionY == 0 && map[i].NextDoorPosition == 3)
                            {
                                i++;
                                Console.WriteLine(i);
                                positionX = map[i].Array.GetLength(0) / 2;
                                positionY = map[i].Array.GetLength(1) - 2;
                                map[i].Array[map[i].Array.GetLength(0) / 2, map[i].Array.GetLength(1) - 1] = ".";
                                Movement(map[i], positionX, positionY);
                            }
                            else if(positionY == 0 && map[i].BackDoorPosition == 3)
                            {
                                i--;
                                Console.WriteLine(i);
                                positionX = map[i].Array.GetLength(0) / 2;
                                positionY = map[i].Array.GetLength(1) - 2;
                                map[i].Array[map[i].Array.GetLength(0) / 2, map[i].Array.GetLength(1) - 1] = ".";
                                Movement(map[i], positionX, positionY);
                            }
                            else if (positionX == 0 && map[i].NextDoorPosition == 1)
                            {
                                
                                i++;
                                Console.WriteLine(i);
                                positionX = map[i].Array.GetLength(0) - 2;
                                positionY = map[i].Array.GetLength(1) /2;
                                map[i].Array[map[i].Array.GetLength(0) - 1, map[i].Array.GetLength(1) / 2] = ".";
                                Movement(map[i], positionX, positionY);
                            }
                            else if (positionX == 0 && map[i].BackDoorPosition == 1)
                            {

                                i--;
                                Console.WriteLine(i);
                                positionX = map[i].Array.GetLength(0) - 2;
                                positionY = map[i].Array.GetLength(1) / 2;
                                map[i].Array[map[i].Array.GetLength(0) - 1, map[i].Array.GetLength(1) / 2] = ".";
                                Movement(map[i], positionX, positionY);
                            }
                            else if (positionX == array.GetLength(0) - 1 && map[i].NextDoorPosition == 2)
                            {
                                i++;
                                Console.WriteLine(i);
                                positionX = 1;
                                positionY = map[i].Array.GetLength(1) / 2;
                                map[i].Array[0, map[i].Array.GetLength(1) / 2] = ".";
                                Movement(map[i], positionX, positionY);
                            }
                            else if (positionX == array.GetLength(0) - 1 && map[i].BackDoorPosition == 2)
                            {
                                i--;
                                Console.WriteLine(i);
                                positionX = 1;
                                positionY = map[i].Array.GetLength(1) / 2;
                                map[i].Array[0, map[i].Array.GetLength(1) / 2] = ".";
                                Movement(map[i], positionX, positionY);
                            }
                            
                        }
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
                
            }
        }
    }
}
