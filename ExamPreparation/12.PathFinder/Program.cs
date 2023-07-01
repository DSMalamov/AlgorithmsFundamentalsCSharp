using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace _12.PathFinder
{
    internal class Program
    {
        private static List<int>[] graph;
        private static List<int> elements;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph= new List<int>[n];
            

            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[node]= new List<int>();
                }
                else
                {
                    graph[node]= line.Split(" ").Select(int.Parse).ToList();
                }
            }

            int path = int.Parse(Console.ReadLine());

            for (int el = 0; el < path; el++)
            {
                var currPath = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
                elements = new List<int>();
                var firstNode = currPath[0];
                elements.Add(firstNode);

                DFS(currPath, 0);

                var a = elements.SequenceEqual(currPath);

                if (a)
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }

            }
            
        }

        private static void DFS(List<int> currPath, int idx)
        { 

            var currNode = currPath[idx];

            foreach (var child in graph[currNode])
            {
                if (currPath[idx + 1] == child)
                {
                    elements.Add(child);
                    DFS(currPath, idx + 1);

                }
            }
            
        }
    }
}
