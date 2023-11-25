using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ukol2
{
    internal class Program
    {
        static void Main(string[] args) //asks for an user input regarding the size of the array, checks wheter it is an int and initiates all of the other methods
        {
            int x = GetElement();
            int y = GetElement();

            int[,] array = MakeArray(x, y);
            Print2DArray(array);
            ChooseAction(array);

        }
        static int[,] MakeArray(int x, int y)//creates an array, filling it with ints in ascending order
        {
            int[,] array = new int[x, y];
            int count = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {

                    count++;
                    array[i, j] = count;
                }
            }
            return array;
        }
        static void Print1DArray(int[] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[i]);
                Console.Write(" ");
            }
        }
        static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("");
        }
        static void ChooseAction(int[,] array)
        {

            while (true)
            {

                Console.WriteLine("choose action:");
                Console.WriteLine("1. get row");
                Console.WriteLine("2. get column");
                Console.WriteLine("3. switcheroo");
                Console.WriteLine("4. row switcheroo");
                Console.WriteLine("5. column switcheroo");
                Console.WriteLine("6. diagonal uno reverse");
                Console.WriteLine("7. Second Diagonal Uno Reverse");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Print1DArray(GetRow(array));
                        break;

                    case "2":
                        Print1DArray(GetColumn(array));
                        break;
                    case "3":
                        Print2DArray(Switcheroo(array));
                        break;
                    case "4":
                        Print2DArray(RowSwitcheroo(array));
                        break;
                    case "5":
                        Print2DArray(ColumnSwitcheroo(array));
                        break;
                    case "6":
                        Print2DArray(DiagonalUnoReverse(array));
                        break;
                    case "7":
                        Print2DArray(SecondDiagonalUnoReverse(array));
                        break;
                    case "8":
                        Print2DArray(Multipla(array));
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        break;
                }
                Console.WriteLine("");
            }
        }
        static int GetElement()
        {
            while (true)
            {
                Console.WriteLine("eyo give me input(preferably a number)");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    return number;
                }
                else { Console.WriteLine("something wrong"); }
            }
        }
        static int[] GetRow(int[,] array)
        {
            int[] row = new int[array.GetLength(1)];
            while (true)
            {
                int index = GetElement();
                if (index >= 0 && index < array.GetLength(0))
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        row[i] = array[index, i];
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("out of bounds :(");
                }
            }
            return row;
        }

        static int[] GetColumn(int[,] array)
        {

            int[] column = new int[array.GetLength(0)];
            while (true)
            {
                int index = GetElement();
                if (index >= 0 && index < array.GetLength(1))
                {
                    column = new int[array.GetLength(0)];

                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        column[i] = array[i, index];
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid column index. Please enter a valid index.");
                }
            }

            return column;
        }
        static int[,] Switcheroo(int[,] array)
        {
            int xFirst, yFirst, xSecond, ySecond;

            xFirst = 0;
            yFirst = 0;
            xSecond = array.GetLength(0) - 1;
            ySecond = array.GetLength(1) - 1;

            int a = array[xFirst, yFirst];
            int b = array[xSecond, ySecond];
            array[xFirst, yFirst] = b;
            array[xSecond, ySecond] = a;
            return array;
        }
        static int[,] RowSwitcheroo(int[,] array)
        {
            int nRowSwap = GetElement();
            int mRowSwap = GetElement();
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
            return array;
        }
        static int[,] ColumnSwitcheroo(int[,] array)
        {
            int nColSwap = GetElement();
            int mColSwap = GetElement();
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
            return array;
        }
        static int[,] DiagonalUnoReverse(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            int[] diagonal = new int[Math.Min(rows, cols)];

            for (int i = 0; i < diagonal.Length; i++)
            {
                diagonal[i] = array[i, i];
            }
            Array.Reverse(diagonal);

            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[i, i] = diagonal[i];
            }
            return array;
        }
        static int[,] SecondDiagonalUnoReverse(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            int[] sDiagonal = new int[Math.Min(rows, columns)];

            for (int i = 0; i < sDiagonal.Length; i++)
            {
                sDiagonal[i] = array[i, columns - i - 1];
            }

            Array.Reverse(sDiagonal);

            for (int i = 0; i < sDiagonal.Length; i++)
            {
                array[i, columns - i - 1] = sDiagonal[i];
            }

            return array;
        }
        static int[,] Multipla(int[,] array)
        {

            int[,] secondArray = MakeArray(array.GetLength(1), 5);
            int[,] mArray = MakeArray(array.GetLength(0), secondArray.GetLength(1));
            int[] row = new int[array.GetLength(0)];
            int[] column = new int[array.GetLength(0)];
            for(int i = 0; i < row.Length; i++)
            {
                row[i] = array[0, i];
                column[i] = array[i, 0]; 
            }
            for (int i=0; i < mArray.GetLength(0); i++)
            {

                for (int j=0; i < mArray.GetLength(1); i++)
                {
                     
                    for (int k=0; k < row.Length;k++)
                    {
                        mArray[i, j] += row[k] * column[k];
                    }
                }
            }

            return mArray;
        }
    }
}

