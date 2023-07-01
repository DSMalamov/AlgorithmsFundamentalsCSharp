using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _14.Paths
{
    internal class Paths
    {
        private static List<int>[] graph;
        private static HashSet<int> steps;

        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());

            if (nodesCount>0)
            {
                graph = new List<int>[nodesCount - 1];

                FillGraph();

                for (int node = 0; node < graph.Length; node++)
                {
                    steps = new HashSet<int>();
                    DFS(node);
                }
            }
            
        }

        private static void FillGraph()
        {
            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }
        }

        private static void DFS(int node)
        {
            steps.Add(node);

            if (node == graph.Length)
            {
                Console.WriteLine(string.Join(' ', steps));
                return;
            }

            foreach (int child in graph[node])
            {
                DFS(child);
                steps.Remove(child);
            }
        }
    }
}
