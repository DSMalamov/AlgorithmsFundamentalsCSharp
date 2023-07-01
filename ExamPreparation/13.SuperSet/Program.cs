using System;
using System.Linq;

namespace _13.SuperSet
{
    internal class Program
    {
        private static int[] input;
        private static int[] combinations;
        private static int slots;

        static void Main(string[] args)
        {
            input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                slots = i;
                combinations= new int[slots];
                GetCombinations(0, 0);
            }

            Console.WriteLine(string.Join(" ", input));
        }

        private static void GetCombinations(int index, int elIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elIndex; i < input.Length; i++)
            {
                combinations[index] = input[i];

                GetCombinations(index + 1, i + 1);
            }
        }
    }
}
