﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Rumors
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            visited = new bool[n + 1];
            parent= new int[n + 1];

            Array.Fill(parent, -1);


            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int from = line[0];
                int to = line[1];

                graph[from].Add(to);
                graph[to].Add(from);
            }

            int start = int.Parse(Console.ReadLine());

            BFS(start);
        }

        private static void BFS(int start)
        {
            var que = new Queue<int>();
            que.Enqueue(start);

            visited[start] = true;
            

            while (que.Count > 0)
            {
                var node = que.Dequeue();

                foreach (var child in graph[node])
                {
                    if (visited[child])
                    {
                        continue;
                    }

                    visited[child] = true;
                    que.Enqueue(child);
                    parent[child] = node;

                    Console.WriteLine($"{start} -> {child} ({GetSteps(parent, node)})");
                }


                
            }
        }

        private static int GetSteps(object patent, int node)
        {
            var steps = 0;

            while (node != -1)
            {
                node = parent[node];
                steps++;
            }

            return steps;
        }
    }
}
