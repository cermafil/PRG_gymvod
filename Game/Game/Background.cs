using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Background
    {
        public static List<string[,]> map = new List<string[,]>();

        public int BackDoorPosition;
        public int NextDoorPosition;
        public string[,] Array;
        public List<Enemy> enemies = new List<Enemy>();
        public static Random random = new Random();

        public Background(int backDoorPosition, int nextDoorPosition)
        {
            BackDoorPosition = backDoorPosition;
            NextDoorPosition = nextDoorPosition;
            Array = MakeBackground(backDoorPosition, nextDoorPosition);
        }

        public static string[,] MakeBackground(int backDoorPosition, int nextDoorPosition)
        {
            int width = random.Next(5, 17); // Random width between 2 and 50
            int height = random.Next(5, 17); // Random height between 2 and 50

            string[,] array = new string[height, width];

            // Fill the array with dots in the middle
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    {
                        array[i, j] = "#";
                    }
                    else
                    {
                        array[i, j] = ".";
                    }
                }
            }
            
            
            // Mark the back door on the specified wall
            MarkDoor(array, backDoorPosition, ".");

            // Mark the next door on the specified wall
            MarkDoor(array, nextDoorPosition, ".");

            return array;
        }

        public static void MarkDoor(string[,] array, int doorPosition, string doorSymbol)
        {
            if (doorPosition == 0)
            {
                // No door specified, do nothing
                return;
            }
            switch (doorPosition)
            {
                case 1: // Top wall
                    int doorXTop = array.GetLength(1) / 2;
                    array[0, doorXTop] = doorSymbol;
                    break;

                case 2: // Bottom wall
                    int doorXBottom = array.GetLength(1) / 2;
                    array[array.GetLength(0) - 1, doorXBottom] = doorSymbol;
                    break;

                case 3: // Left wall
                    int doorYLeft = array.GetLength(0) / 2;
                    array[doorYLeft, 0] = doorSymbol;
                    break;

                case 4: // Right wall
                    int doorYRight = array.GetLength(0) / 2;
                    array[doorYRight, array.GetLength(1) - 1] = doorSymbol;
                    break;

                default:
                    break;
            }
        }
    

    public static void PrintArray(string[,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        

        public static List<Background> MakeMap(Background start)
        {
            
            List<Background> map = new List<Background>();
            start.Array[0, 0] = "s";
            map.Add(start);
            
            for (int i = 0; i < 50; i++)
            {
                int rand = 0;
                
                if (map[i].NextDoorPosition == 1)
                {

                    
                    while (true)
                    {
                        
                        rand = random.Next(1, 5);
                        if (rand != 2)
                        {
                            break;
                        }
                    }
                     
                    Background background = new Background(2, rand);
                    background.Array[0, 0] = i.ToString();
                    map.Add(background);
                }
                else if (map[i].NextDoorPosition == 2)
                {
                    
                    while (true)
                    {
                        
                        rand = random.Next(1, 5);
                        if (rand != 1)
                        {
                            break;
                        }
                    }
                     
                    Background background = new Background(1, rand);
                    background.Array[0, 0] = i.ToString();
                    map.Add(background);
                }
                else if (map[i].NextDoorPosition == 3)
                {
                    
                    while (true)
                    {
                        
                        rand = random.Next(1, 5);
                        if (rand != 4)
                        {
                            break;
                        }
                    }
                     
                    Background background = new Background(4, rand);
                    background.Array[0, 0] = i.ToString();
                    map.Add(background);
                }
                else if (map[i].NextDoorPosition == 4)
                {
                    
                    while (true)
                    {
                        
                        rand = random.Next(1, 5);
                        if (rand != 3)
                        {
                            break;
                        }
                    }
                    
                    
                    Background background = new Background(3, rand);
                    background.Array[0, 0] = i.ToString();
                    map.Add(background);
                }
                
                
            }

            return map;
        }

    }
}
