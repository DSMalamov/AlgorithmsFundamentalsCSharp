using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Linq;

namespace _08.Universes
{
    internal class Program
    {
        private static Dictionary<string,string> graph;
        private static List<string> visited;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string,string>();
            visited = new List<string>();
            var count = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" - ");

                var p1 = input[0];
                var p2 = input[1];

                graph[p1] = p2;
            }

            foreach (var item in graph)
            {
                var comp = new List<string>();

                DFS(item.Key,item.Value, comp);

                if (comp.Count > 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);

        }

        private static void DFS(string key, string value, List<string> comp)
        {

            if (visited.Contains(key))
            {
                return;
            }

            visited.Add(key);

            if (graph.ContainsKey(value))
            {
                var newkey = value;
                var newValue = graph[value];
                DFS(newkey, newValue, comp);
            }

            comp.Add(key);
        }

     

    }
}
