using System;

namespace _01.BitcoinMiners
{
    internal class Program
    {
        private static int n;
        private static int combinations;
        private static int slots;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            slots = int.Parse(Console.ReadLine());

            combinations = 0;

            Combinatios(0, 0);

            Console.WriteLine(combinations);
        }

        private static void Combinatios(int index, int elementIndex)
        {
            if (index >= slots)
            {
                combinations++;
                return;
            }

            for (int i = elementIndex; i < n; i++)
            {
                Combinatios(index + 1, i + 1);
            }
        }
    }
}
