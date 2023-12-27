using System;
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
            Background background1 = new Background(1);
            int a = background1.DoorPosition;
            string[,] array = background1.Array;
            array[1, 1] = "@";
            Background.PrintArray(array);
            PlayerMovement.Movement(background1);
             // Example: Create a background with a door on the left wall (3)
            

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