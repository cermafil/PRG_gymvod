using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy
    {
        
        public int positionX;
        public int positionY;
        public int health = 5;
        public  bool alive = true;
        public Enemy(int positionX, int positionY, int health, bool alive)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.health = health;
            this.alive = alive;
        }

        public void Update(Background map, int playerX, int playerY, Enemy enemy)
        {
            Random random = new Random();

            
            
            if (health > 0)
            {
                map.Array[enemy.positionX, enemy.positionY] = ".";

                if (playerX > enemy.positionX && map.Array[enemy.positionX + 1, enemy.positionY] == ".")
                    {
                        enemy.positionX++;
                    }
                    else if (playerX < enemy.positionX && map.Array[enemy.positionX - 1, enemy.positionY] == ".")
                    {
                        enemy.positionX--;
                    }

                    if (playerY > enemy.positionY && map.Array[enemy.positionX, enemy.positionY + 1] == ".")
                    {
                        enemy.positionY++;
                    }
                    else if (playerY < enemy.positionY && map.Array[enemy.positionX, enemy.positionY - 1] == ".")
                    {
                        enemy.positionY--;
                    }
                    map.Array[enemy.positionX, enemy.positionY] = "k";
                
            }
            else
            {
                map.Array[enemy.positionX, enemy.positionY] = ".";
            }
            
            // Update the map with the new enemy.position of the enemy
            
        }
    }
}
