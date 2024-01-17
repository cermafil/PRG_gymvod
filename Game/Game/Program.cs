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
            Console.WriteLine($"Hello {name}, and welcome to my game called the Rock Stew!!");
            Console.WriteLine("on your way you will find enemies, kill them by running into them, just like in real life");
            Console.WriteLine("use numpad to move around");
            Console.WriteLine("may the odds be ever in your favor and god speed");
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
