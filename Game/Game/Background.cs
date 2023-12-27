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

        public int DoorPosition;
        public string[,] Array;

        private static Random random = new Random();

        public Background(int doorPosition)
        {
            DoorPosition = doorPosition;
            Array = MakeBackground(doorPosition);
        }
        public static string[,] MakeBackground(int doorPosition)
        {
            int width = random.Next(3, 17); // Random width between 2 and 50
            int height = random.Next(3, 17); // Random height between 2 and 50

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
            
            // Mark the door on the specified wall
            switch (doorPosition)
            {
                case 1: // Top wall
                    int doorXTop = width / 2;
                    array[0, doorXTop] = "D";
                    break;

                case 2: // Bottom wall
                    int doorXBottom = width / 2;
                    array[height - 1, doorXBottom] = "D";
                    break;

                case 3: // Left wall
                    int doorYLeft = height / 2;
                    array[doorYLeft, 0] = "D";
                    break;

                case 4: // Right wall
                    int doorYRight = height / 2;
                    array[doorYRight, width - 1] = "D";
                    break;

                default:
                   
                    break;
            }

            

            return array;
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
            map.Add(start);
            Console.WriteLine("0");
            for (int i = 0; i < 10; i++)
            {
                
                if (map[i].DoorPosition == 1)
                {
                    
                    Background background = new Background(2);
                    map.Add(background);
                }
                else if (map[i].DoorPosition == 2)
                {
                    Console.WriteLine("2");
                    Background background = new Background(1);
                    map.Add(background);
                }
                else if (map[i].DoorPosition == 3)
                {
                    Console.WriteLine("3");
                    Background background = new Background(4);
                    map.Add(background);
                }
                else if (map[i].DoorPosition == 4)
                {
                    Console.WriteLine("4");
                    Background background = new Background(3);
                    map.Add(background);
                }
                
                
            }

            return map;
        }

    }
}
