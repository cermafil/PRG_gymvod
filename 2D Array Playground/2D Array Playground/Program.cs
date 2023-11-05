using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] array = new int[5, 5];
            int x = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    
                    x++;
                    array[i, j] = x;
                    
                }
            }
            /*
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write(" ");
                    

                }
                Console.Write("\n");
            }
            Console.WriteLine();
            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 2;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[nRow, i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[i, nColumn]);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine();
            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst, yFirst, xSecond, ySecond;
            xFirst = 1;
            yFirst = 1;
            xSecond = 4;
            ySecond = 4;
            
            int a = array[xFirst, yFirst];
            int b = array[xSecond, ySecond];
            array[xFirst, yFirst] = b;
            array[xSecond, ySecond] = a;
             
            
            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;
            int[] radek = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                radek[i] = array[nRowSwap, i];
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[nRowSwap, i] = array[mRowSwap, i];
                array[mRowSwap, i] = radek[i];
                
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write(" ");


                }
                Console.Write("\n");
            }
            Console.WriteLine();
            
            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 1;
            int[] sloupec = new int[array.GetLength(1)];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                sloupec[i] = array[i, nColSwap];
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[i, nColSwap] = array[i, mColSwap];
                array[i, mColSwap] = sloupec[i];

            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write(" ");


                }
                Console.Write("\n");
            }
            
            //BONUS
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine(array[i, i]);
                 
            }
            
            
            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.
            int[] diagonala = new int[array.GetLength(1)];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                diagonala[i] = array[i, i];
            }
            Array.Reverse(diagonala);
            for (int i = 0; i < array.GetLength(1); i++)
            {
                Console.WriteLine(diagonala[i]);
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[i, i] = diagonala[i];
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write(" ");


                }
                Console.Write("\n");
            }
            */
            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.
            int[] vDiagonala = new int[array.GetLength(1)];

            for (int i = array.GetLength(1); i > 0; i--)
            {
                vDiagonala[array.GetLength(1) - i] = (array[array.GetLength(1) - i, i - 1]);
            }
            Array.Reverse(vDiagonala);
             
            for (int i = array.GetLength(1); i > 0; i--)
            {
                array[array.GetLength(1) - i, i - 1] = vDiagonala[i];
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write(" ");


                }
                Console.Write("\n");
            }
            
            for (int i = array.GetLength(1) ; i > 0; i--)
            {
                Console.WriteLine(array[array.GetLength(1) - i, i - 1]);
            }
            Console.ReadKey();
        }
    }
}
