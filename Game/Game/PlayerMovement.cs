using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game
{
    internal class PlayerMovement
    {
        public static int positionX;
        public static int positionY;
        public static List<Background> exploredRooms = new List<Background>();
        
        public PlayerMovement(int startX, int startY)
        {
            positionX = startX;
            positionY = startY;

        }
        public static int i = 0;
        public static Background start = new Background(0, 1);
        public static List<Background> map = Background.MakeMap(start);
        public static PlayerMovement player = new PlayerMovement(positionX, positionY);
        
        public static void Movement(Background background, int positionX, int positionY)
        {
            
            SpawnEnemy(map[i], i);
            
            exploredRooms.Add(map[i]);
            
            string[,] array = background.Array;
            List<Enemy> list = SpawnEnemy(background, i);
            //stolen from chatgpt but I sort of get what it does

            //creates variable with the smallest possible value of DateTime, just to initialise it

            DateTime pressTime = DateTime.MinValue;
            //creates variable cooldown with the value of 50 milliseconds
            TimeSpan cooldown = TimeSpan.FromMilliseconds(50);
            while (true)
            {
                foreach (Enemy enemy in list)
                {

                    enemy.Update(background, positionX, positionY, enemy);
                }
                if (LookForEnemy(array) == true)
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            if (array[i, j] == "." && (i == 0 || i == array.GetLength(0) - 1 || j == 0 || j == array.GetLength(1) - 1))
                            {
                                array[i, j] = "X";
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            if (array[i, j] == "X")
                            {
                                array[i, j] = ".";
                            }
                        }
                    }
                }
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
                        
                        player.CheckDoor(positionX, positionY, array, "@");


                        // Handle movement based on the pressed key
                        // Store the original value before moving the player
                        string originalValue = array[positionX, positionY];
                        if (array[previousX, previousY] == "@")
                        {
                            originalValue = ".";
                        }
                        

                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.NumPad6:
                                if (array[positionX, positionY + 1] == "k")
                                {
                                    player.HitEnemy(list, array, positionX, positionY + 1);
                                }
                                else if (array[positionX, positionY + 1] == ".")
                                {
                                    array[positionX, positionY] = originalValue;
                                    positionY++;
                                    array[positionX, positionY] = "@";
                                }
                                break;

                            case ConsoleKey.NumPad4:
                                if (array[positionX, positionY - 1] == "k")
                                {
                                    player.HitEnemy(list, array, positionX, positionY - 1);
                                }
                                else if (array[positionX, positionY - 1] == ".")
                                {
                                    array[positionX, positionY] = originalValue;
                                    positionY--;
                                    array[positionX, positionY] = "@";
                                }
                                break;

                            case ConsoleKey.NumPad8:
                                if (array[positionX - 1, positionY] == "k")
                                {
                                    player.HitEnemy(list, array, positionX - 1, positionY);
                                }
                                else if (array[positionX - 1, positionY] == ".")
                                {
                                    array[positionX, positionY] = originalValue;
                                    positionX--;
                                    array[positionX, positionY] = "@";
                                }
                                break;

                            case ConsoleKey.NumPad2:
                                if (array[positionX + 1, positionY] == "k")
                                {
                                    player.HitEnemy(list, array, positionX + 1, positionY);
                                }
                                else if (array[positionX + 1, positionY] == ".")
                                {
                                    array[positionX, positionY] = originalValue;
                                    positionX++;
                                    array[positionX, positionY] = "@";
                                }
                                break;

                            case ConsoleKey.NumPad1:
                                if (array[positionX + 1, positionY - 1] == "k")
                                {
                                    player.HitEnemy(list, array, positionX + 1, positionY - 1);
                                }
                                else if (array[positionX + 1, positionY - 1] == ".")
                                {
                                    array[positionX, positionY] = originalValue;
                                    positionX++;
                                    positionY--;
                                    array[positionX, positionY] = "@";
                                }
                                break;

                            case ConsoleKey.NumPad3:
                                if (array[positionX + 1, positionY + 1] == "k")
                                {
                                    player.HitEnemy(list, array, positionX + 1, positionY + 1);
                                }
                                else if (array[positionX + 1, positionY + 1] == ".")
                                {
                                    array[positionX, positionY] = originalValue;
                                    positionX++;
                                    positionY++;
                                    array[positionX, positionY] = "@";
                                }
                                break;

                            case ConsoleKey.NumPad7:
                                if (array[positionX - 1, positionY - 1] == "k")
                                {
                                    player.HitEnemy(list, array, positionX - 1, positionY - 1);
                                }
                                else if (array[positionX - 1, positionY - 1] == ".")
                                {
                                    array[positionX, positionY] = originalValue;
                                    positionX--;
                                    positionY--;
                                    array[positionX, positionY] = "@";
                                }
                                break;

                            case ConsoleKey.NumPad9:
                                if (array[positionX - 1, positionY + 1] == "k")
                                {
                                    player.HitEnemy(list, array, positionX - 1, positionY + 1);
                                }
                                else if (array[positionX - 1, positionY + 1] == ".")
                                {
                                    array[positionX, positionY] = originalValue;
                                    positionX--;
                                    positionY++;
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
        public void CheckDoor(int positionX, int positionY, string[,] array, string character)
        {
            
            if (positionY == array.GetLength(1) - 1 || positionY == 0 || positionX == array.GetLength(0) - 1 || positionX == 0)
            {
                
                
                if (positionY == array.GetLength(1) - 1 && map[i].NextDoorPosition == 4)
                {
                    
                    i++;
                    
                    positionX = map[i].Array.GetLength(0) / 2;
                    positionY = 1;
                    map[i].Array[map[i].Array.GetLength(0) / 2, 0] = ".";
                    map[i].Array[positionX, positionY] = character;
                    Movement(map[i], positionX, positionY);

                }

                else if (positionY == array.GetLength(1) - 1 && map[i].BackDoorPosition == 4)
                {
                    i--;
                    

                    positionX = map[i].Array.GetLength(0) / 2;
                    positionY = 1;
                    map[i].Array[map[i].Array.GetLength(0) / 2, 0] = ".";
                    map[i].Array[positionX, positionY] = character;
                    Movement(map[i], positionX, positionY);
                }
                else if (positionY == 0 && map[i].NextDoorPosition == 3)
                {
                    i++;
                    
                    
                    positionX = map[i].Array.GetLength(0) / 2;
                    positionY = map[i].Array.GetLength(1) - 2;
                    map[i].Array[map[i].Array.GetLength(0) / 2, map[i].Array.GetLength(1) - 1] = ".";
                    map[i].Array[positionX, positionY] = character;
                    Movement(map[i], positionX, positionY);
                }
                else if (positionY == 0 && map[i].BackDoorPosition == 3)
                {
                    i--;
                    
                    positionX = map[i].Array.GetLength(0) / 2;
                    positionY = map[i].Array.GetLength(1) - 2;
                    map[i].Array[map[i].Array.GetLength(0) / 2, map[i].Array.GetLength(1) - 1] = ".";
                    map[i].Array[positionX, positionY] = character;
                    Movement(map[i], positionX, positionY);
                }
                else if (positionX == 0 && map[i].NextDoorPosition == 1)
                {

                    i++;
                    
                    
                    positionX = map[i].Array.GetLength(0) - 2;
                    positionY = map[i].Array.GetLength(1) / 2;
                    map[i].Array[map[i].Array.GetLength(0) - 1, map[i].Array.GetLength(1) / 2] = ".";
                    map[i].Array[positionX, positionY] = character;
                    Movement(map[i], positionX, positionY);
                }
                else if (positionX == 0 && map[i].BackDoorPosition == 1)
                {

                    i--;
                    
                    positionX = map[i].Array.GetLength(0) - 2;
                    positionY = map[i].Array.GetLength(1) / 2;
                    map[i].Array[map[i].Array.GetLength(0) - 1, map[i].Array.GetLength(1) / 2] = ".";
                    map[i].Array[positionX, positionY] = character;
                    Movement(map[i], positionX, positionY);
                }
                else if (positionX == array.GetLength(0) - 1 && map[i].NextDoorPosition == 2)
                {
                    i++;
                    
                    
                    positionX = 1;
                    positionY = map[i].Array.GetLength(1) / 2;
                    map[i].Array[0, map[i].Array.GetLength(1) / 2] = ".";
                    map[i].Array[positionX, positionY] = character;
                    Movement(map[i], positionX, positionY);
                }
                else if (positionX == array.GetLength(0) - 1 && map[i].BackDoorPosition == 2)
                {
                    i--;
                    
                    positionX = 1;
                    positionY = map[i].Array.GetLength(1) / 2;
                    map[i].Array[0, map[i].Array.GetLength(1) / 2] = ".";
                    map[i].Array[positionX, positionY] = character;
                    Movement(map[i], positionX, positionY);
                }
                
                
            }

        }
        public static bool LookForEnemy(string[,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);
            bool status = false;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (array[i, j] == "k")
                    {
                        status = true;
                    }
                }

            }
             
            if (status)
            {
                return true;
            }
            else {
                
                return false; }
        }
        public static List<Enemy> SpawnEnemy(Background map, int numberOfEnemies)
        {
            Random random = new Random();

            for (int i = 0; i < numberOfEnemies; i++)
            {
                int positionX = random.Next(1, map.Array.GetLength(0) - 2);
                int positionY = random.Next(1, map.Array.GetLength(1) - 2);

                Enemy enemy = new Enemy(positionX, positionY, 5, true);
                Console.WriteLine();

                map.enemies.Add(enemy);
            }

            return map.enemies;
        }
        public void HitEnemy(List<Enemy> list, string[,] array, int positionX, int positionY)
        {
            
                foreach (Enemy enemy in list)
                {
                if (enemy.positionX == positionX && enemy.positionY == positionY)
                {
                    enemy.health--;
                    
                }    
                }
                
            
        }

        
    }
    
}