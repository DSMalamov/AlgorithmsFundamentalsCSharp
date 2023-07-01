using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.BitcoinTransactions
{
    internal class Program
    {
        private static Dictionary<string,string> graph;
        private static List<string> visited;
        private static int groups;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, string>();
            visited = new List<string>();
            groups = 0;

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                graph[line[0]] = line[1];
                graph[line[1]] = string.Empty;

            }

            foreach (var kvp in graph)
            {
                if (!visited.Contains(kvp.Key))
                {
                    DFS(kvp.Key);
                }
            }

            if (groups == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(groups);
            }
            

        }

        private static void DFS(string node)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);

                if (graph[node] == String.Empty)
                {
                    groups += 1;
                }
                else
                {
                    DFS(graph[node]);
                }
            }
        }
    }
}
