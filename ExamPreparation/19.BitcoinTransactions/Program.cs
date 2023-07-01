using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _19.BitcoinTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine()
                .Split()
                .ToArray();

            var arr2 = Console.ReadLine()
                .Split()
                .ToArray();

            var lcs = new int[arr1.Length + 1, arr2.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (arr1[r-1] == arr2[c-1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
                    }
                }
            }

            var row = lcs.GetLength(0) - 1;
            var col = lcs.GetLength(1) - 1;
            var hValue = lcs[row, col];

            for (int r = lcs.GetLength(0) - 1; r >= 0; r--)
            {
                for (int c = lcs.GetLength(1) - 1; c >= 0; c--)
                {
                    if (lcs[r,c] == hValue)
                    {
                        row = r;
                        col = c;
                    }
                }
            }

            var seq = new Stack<string>();

            while (row > 0 && col > 0)
            {
                if (arr1[row-1] == arr2[col-1] && lcs[row, col] == lcs[row-1,col-1]+1)
                {
                    seq.Push(arr1[row - 1]);
                    row--;
                    col--;

                }
                else if (lcs[row-1,col] > lcs[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            Console.WriteLine($"[{string.Join(" ", seq)}]");
        }
    }
}
