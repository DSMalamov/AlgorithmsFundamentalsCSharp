using System;

namespace _10.TBC
{
    internal class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static int size;
        private static int tunels;

        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            matrix= new char[r, c];
            visited = new bool[r, c];
            

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                size = 0;
                GindHorizontalTunel(row, 0);
            }
        }

        private static void GindHorizontalTunel(int row, int col)
        {
            if (IsOutside(row, col) || IsDirt(row, col))
            {
                return;
            }


        }

        

        private static bool IsDirt(int row, int col)
        {
            return matrix[row, col] == 'd';
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }
    }
}
