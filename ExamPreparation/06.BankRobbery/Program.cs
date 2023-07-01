using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace _06.BankRobbery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var boxes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var allSums = FindAllSums(boxes);

            var sum = boxes.Sum();

            var target = sum / 2;

            var joshBoxes = FindSubset(allSums, target);
            var prakashBoxes = boxes.ToList();

            foreach (var box in joshBoxes)
            {
                prakashBoxes.Remove(box);
            }

            Console.WriteLine(string.Join(" ", joshBoxes.OrderBy(x => x)));
            Console.WriteLine(string.Join(" ", prakashBoxes.OrderBy(x => x)));
            

        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var result = new List<int>();

            while (target != 0)
            {
                var element = sums[target];

                result.Add(element);

                target -= element;
            }

            return result;
        }

        private static Dictionary<int, int> FindAllSums(int[] boxes)
        {
            var sums = new Dictionary<int, int>() { { 0,0 } };

            foreach (var box in boxes)
            {
                var currSum = sums.Keys.ToArray();

                foreach (var sum in currSum)
                {
                    var newSum = sum + box;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, box);
                }
            }

            return sums;
        }
    }
}
