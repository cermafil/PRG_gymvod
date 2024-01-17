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
        public int health = 10;
        public  bool alive = true;
        public Background room; 
        public Enemy(int positionX, int positionY, int health, bool alive, Background room)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.health = health;
            this.alive = alive;
            this.room = room;   
            this.room = room;
        }

        public void Update(Background map, int playerX, int playerY, Enemy enemy)
        {
            // Check if the player is present in the same array
            

                    // Check if the enemy is alive
                    if (health > 0)
                    {


                // Calculate the distance between player and enemy
                        int distanceX = Math.Abs(playerX - enemy.positionX);
                        int distanceY = Math.Abs(playerY - enemy.positionY);

                        // Check if the player is within a certain distance8
                        if (distanceX <= 3 && distanceY <= 3)
                        {
                            // Clear the current position of the enemy
                            map.Array[enemy.positionX, enemy.positionY] = ".";
                            
                            // Move the enemy towards the player
                            if (playerX > enemy.positionX && map.Array[enemy.positionX + 1, enemy.positionY] == "." && enemy.positionX < map.Array.GetLength(0) - 1)
                            {
                                enemy.positionX++;
                            }
                            else if (playerX < enemy.positionX && map.Array[enemy.positionX - 1, enemy.positionY] == "." && enemy.positionX > 0)
                            {
                                enemy.positionX--;
                            }

                            if (playerY > enemy.positionY && map.Array[enemy.positionX, enemy.positionY + 1] == "." && enemy.positionY < map.Array.GetLength(1) - 1)
                            {
                                enemy.positionY++;
                            }
                            else if (playerY < enemy.positionY && map.Array[enemy.positionX, enemy.positionY - 1] == "." && enemy.positionY > 0)
                            {
                                enemy.positionY--;
                            }

                            // Set the new position of the enemy
                            map.Array[enemy.positionX, enemy.positionY] = "k";
                        }
                        else
                        {
                            map.Array[enemy.positionX, enemy.positionY] = "k";
                        }
                    }
                    else
                    {
                        // If the enemy is not alive, clear its position
                        map.Array[enemy.positionX, enemy.positionX] = ".";
                    }
             
            // If the player is not present or in a different room, do nothing (enemy won't move)
        }

    }
}
