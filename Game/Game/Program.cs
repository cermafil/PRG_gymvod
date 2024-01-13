using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string difficulty = "normal";
            Console.WriteLine("Whats your name?");
            string name = Console.ReadLine();
            if(name == "Yeenya" || name == "yeenya")
            {
                difficulty = "yeenya";
            }
            Background Start = new Background(0, 1);
            List<Background> Map = Background.MakeMap(Start);
            PlayerMovement player = new PlayerMovement(1, 1, Map, name);
            PlayerMovement.playerHealth = 50;

            Console.WriteLine("press any key to continue");
            List<Background> map = PlayerMovement.map;
            map[0].Array[1, 1] = "@";
            map[0].Array[0, 0] = "s";
            Background start = map[0];
            PlayerMovement.Movement(start, 1, 1);
            Console.WriteLine($"congratulations you have made it to the room: {PlayerMovement.i - 1}");
            Console.WriteLine("you died :(, if you want to play again restart the program");
            Console.ReadKey();

        }
    }
}
