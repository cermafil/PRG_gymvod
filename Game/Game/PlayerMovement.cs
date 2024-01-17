using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        
        public static int playerHealth = 50;
        public static int maxHealth = 50;
        public static int lvl = 1;
        public static int lvlThreshold = 5;
        public static int exp = 0;
        public static int dmg = 1;
        
        public static string name;
        public static string difficulty;

        public PlayerMovement(int startX, int startY, string name)
        {
            positionX = startX;
            positionY = startY;
            
            PlayerMovement.name = name;
            
        }
        public static int i = 0;
        public static Background start = new Background(0, 1);
        public static List<Background> map = Background.MakeMap(start);
        public static PlayerMovement player = new PlayerMovement(positionX, positionY, name);
        
        public static void Movement(Background background, int positionX, int positionY)
        {
            
            if(exp >= lvlThreshold)
            {
                lvl++;
                maxHealth += 10;
                exp = 0;
                lvlThreshold *= 5;
                dmg++;
            }
            SpawnEnemy(map[i], i);
            exploredRooms.Add(background);
            string[,] array = background.Array;
            List<Enemy> list = SpawnEnemy(background, i);
            //stolen from chatgpt but I sort of get what it does

            //creates variable with the smallest possible value of DateTime, just to initialise it

            DateTime pressTime = DateTime.MinValue;
            //creates variable cooldown with the value of 50 milliseconds
            TimeSpan cooldown = TimeSpan.FromMilliseconds(50);
            
            while (playerHealth > 0)
            {
                try
                {
                    foreach (Enemy enemy in list)
                {
                    enemy.Update(background, positionX, positionY, enemy);
                }
                
                // Check if the current map is not already in exploredRooms

                if (LookForEnemy(array, "k") == true)
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
                        
                        //checks user inputted number and changes array arcondingly
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.NumPad6:
                                //if next position is enemy hit him
                                if (array[positionX, positionY + 1] == "k")
                                {
                                    player.HitEnemy(list, array, positionX, positionY + 1);
                                }
                                //if next position in . move there
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

                        playerHealth = player.GetHit(playerHealth, positionX, positionY, array);

                            //print all the info
                            Console.WriteLine(name);
                            Console.WriteLine($"health: {playerHealth}");
                            Console.WriteLine($"level: {lvl}");
                            Console.WriteLine($"exp: {exp}/{lvlThreshold}");
                            Console.WriteLine($"damage: {dmg}"); 
                            Background.PrintArray(array);
                        //changes the pressTime variable to current time when the key was pressed
                        pressTime = DateTime.Now;   
                    }
                }
            }
            catch (Exception ex)
            {
                    
                return; // Exit the method in case of an error
            }

            }
            
        }
        //checks if player moves through door and puts him into the right room according to the value of i
        public void CheckDoor(int positionX, int positionY, string[,] array, string character)
        {
            if (positionY == array.GetLength(1) - 1 || positionY == 0 || positionX == array.GetLength(0) - 1 || positionX == 0)
            {
                if (playerHealth < maxHealth)
                {
                    if(playerHealth >= (maxHealth - maxHealth/5))
                    {
                        playerHealth = maxHealth;
                    }
                    else
                    { playerHealth = playerHealth + maxHealth / 5; }                 
                }
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
        //loops through the array and looks for enemy
        public static bool LookForEnemy(string[,] array, string character)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);
            bool status = false;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (array[i, j] == character)
                    {
                        status = true;
                    }
                }
            }
            if (status)
            {
                return true;
            }
            else {return false; }
        }
        //if the room is not explored yet it fills it with number of enemies based on the current number of the room
        public static List<Enemy> SpawnEnemy(Background map, int numberOfEnemies)
        {
            Random random = new Random();
            if (!exploredRooms.Contains(map))
            {
                for (int j = 0; j < numberOfEnemies; j++)
                {
                    int positionX, positionY;

                    do
                    {
                        positionX = random.Next(1, map.Array.GetLength(0) - 2);
                        positionY = random.Next(1, map.Array.GetLength(1) - 2);
                    } while (IsPositionOccupied(map, positionX, positionY));

                    Enemy enemy = new Enemy(positionX, positionY, 5, true, map);
                    map.enemies.Add(enemy);
                }
            }
            return map.enemies;
        }

        private static bool IsPositionOccupied(Background map, int x, int y)
        {
            foreach (Enemy existingEnemy in map.enemies)
            {
                if (existingEnemy.positionX == x && existingEnemy.positionY == y)
                {
                    return true; 
                }
            }

            return false; 
        }
        //checks if there is enemy and if so it substracts his health, if he dies it removes him from the list
        public void HitEnemy(List<Enemy> list, string[,] array, int positionX, int positionY)
        {

            for (int i = 0; i < list.Count; i++)
            {
                Enemy enemy = list[i];
                if (enemy.positionX == positionX && enemy.positionY == positionY)
                {
                    enemy.health -= dmg;
                    if(enemy.health <= 0)
                    {
                        exp = exp + 5;
                        list.Remove(enemy);
                        array[enemy.positionX, enemy.positionY] = ".";
                    }
                }
                
            }
        }
        public int GetHit(int health, int x, int y, string[,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            // Check for enemies in the surrounding positions without going out of array bounds

            if (x > 0 && y > 0 && array[x - 1, y - 1] == "k")
            {
                health--;
            }

            if (x > 0 && array[x - 1, y] == "k")
            {
                health--;
            }

            if (x > 0 && y < height - 1 && array[x - 1, y + 1] == "k")
            {
                health--;
            }

            if (y > 0 && array[x, y - 1] == "k")
            {
                health--;
            }

            if (y < height - 1 && array[x, y + 1] == "k")
            {
                health--;
            }

            if (x < width - 1 && y > 0 && array[x + 1, y - 1] == "k")
            {
                health--;
            }

            if (x < width - 1 && array[x + 1, y] == "k")
            {
                health--;
            }

            if (x < width - 1 && y < height - 1 && array[x + 1, y + 1] == "k")
            {
                health--;
            }

            return health;
        }   
    }   
}
    
