using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

namespace _07.MoveDown_Right
{
    internal class Program
    {
        private static long paths;
        private static int[,] matrix;
        private static bool[,] visited;


        static public void Main()
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            paths = 0;
            matrix = new int[r, c];
            visited = new bool[r, c];

            GetPaths(0, 0, string.Empty);

            Console.WriteLine(paths);
        }

        private static void GetPaths(int row, int col)
        {

            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (row == matrix.GetLength(0) - 1 && col == matrix.GetLength(1) - 1)
            {

                paths += 1;
               
            }

            visited[row, col] = true;

            GetPaths(row + 1, col);
            GetPaths(row, col + 1);

            visited[row, col] = false;
        }
    }
}
