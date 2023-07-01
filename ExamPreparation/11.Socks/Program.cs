using System;
using System.Linq;

namespace _11.Socks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var line2 = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var lcs = new int[line1.Length + 1, line2.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (line1[r-1] == line2[c-1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r - 1, c], lcs[r, c - 1]);
                    }
                }
            }

            Console.WriteLine(lcs[line1.Length,line2.Length]);
        }
    }
}
