using System;

namespace Program
{
    class Graph
    {
       public static int[,] matrix = new int[6, 6]
       {
           { 0, 7, 9, 0, 0, 14},
           { 7, 0, 10, 15, 0, 0},
           { 9, 10, 0, 11, 0, 2},
           { 0, 15, 11, 0, 6, 0},
           { 0, 0, 0, 6, 0, 9},
           {14, 0, 2, 0, 9, 0}
        };

        public static void MatrixPrint()
        {
            Console.WriteLine("Adjacency matrix:");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write($"{matrix[i, j]}, ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int[] dijkstra(int start)
        {
            const int n = 6;

            bool[] processed = new bool[n];
            int[] dist = new int[n];
            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[start] = 0;
            int[] parent = new int[n];
            int cur = start;

            parent[start] = start;

            while (!processed[cur])
            {
                processed[cur] = true;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[cur, i] != 0)
                    {
                        int d = dist[cur] + matrix[cur, i];
                        if (d < dist[i])
                        {
                            dist[i] = d;
                            parent[i] = cur;
                        }
                    }
                }

                int minDist = int.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if (!processed[i] && dist[i] < minDist)
                    {
                        cur = i;
                        minDist = dist[i];
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"The distance from the vertex {start + 1} to {i + 1} is equal to {dist[i]}");

                int finish = i;
                Console.Write($"{finish + 1}");
                while (parent[finish] != start)
                {
                    finish = parent[finish];
                    Console.Write($" <= {finish + 1}");
                }
                Console.WriteLine($" <= {start + 1}");
            }
            Console.WriteLine();

            return dist;
        }

        public static int[,] FloydWarshall()
        {
            int[,] dists = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                int[] dist = dijkstra(i);

                for (int j = 0; j < 6; j++)
                {
                    dists[i, j] = dist[j];
                }
            }

            return dists;
        }
    }

    class Program
    {
        public static void Main()
        {
            Graph.MatrixPrint();
            Graph.FloydWarshall();
        }
    }
}