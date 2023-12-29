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
            Background background1 = new Background(0, 1);
            int a = background1.NextDoorPosition;
            string[,] array = background1.Array;
            array[1, 1] = "@";
            Background.PrintArray(array);
            PlayerMovement.Movement(background1, 1, 1);
            
            

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