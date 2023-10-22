using System;
using System.Linq;

class Edge
{
    public int Start { get; set; }
    public int End { get; set; }
    public int Weight { get; set; }
}

class Program
{
    static int[] parent;

    static int Find(int vertex)
    {
        if (parent[vertex] == vertex)
            return vertex;
        return parent[vertex] = Find(parent[vertex]);
    }

    static void Union(int a, int b)
    {
        a = Find(a);
        b = Find(b);
        if (a != b)
            parent[b] = a;
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);

        Edge[] edges = new Edge[M];
        parent = new int[N];

        for (int i = 0; i < N; i++)
            parent[i] = i;

        for (int i = 0; i < M; i++)
        {
            input = Console.ReadLine().Split();
            int A = int.Parse(input[0]) - 1;
            int B = int.Parse(input[1]) - 1;
            int C = int.Parse(input[2]);
            edges[i] = new Edge { Start = A, End = B, Weight = C };
        }

        Array.Sort(edges, (a, b) => a.Weight - b.Weight);

        int minSpanningTreeWeight = 0;

        foreach (var edge in edges)
        {
            if (Find(edge.Start) != Find(edge.End))
            {
                minSpanningTreeWeight += edge.Weight;
                Union(edge.Start, edge.End);
            }
        }

        Console.WriteLine(minSpanningTreeWeight);
    }
}