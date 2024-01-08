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
            Console.WriteLine("press any key to continue");
            List<Background> map = PlayerMovement.map;
            map[0].Array[1, 1] = "@";
            map[0].Array[0, 0] = "s";
            Background start = map[0];

           
            
            PlayerMovement.Movement(start, 1, 1);
        }
       
    }
}
