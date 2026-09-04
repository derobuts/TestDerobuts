namespace DSAandAlgo.Dijkstra;

public class Dijkstra
{

    public static List<(int node, int weight)>[] BuildGraph(int n, int[][] edges, bool directed = true)
    {
        var graph = new List<(int node, int weight)>[n];
        for (int r = 0; r < n; r++)
        {
            graph[r] = new List<(int node, int weight)>();
        }

        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            int weight = edge[2];
            graph[u].Add((v, weight));
        }
        return graph;
    }
    
    public int[] Dijkstra(List<(int node, int weight)>[] graph, int n, int src)
    {
        var dist = new int[n];
        Array.Fill(dist, int.MaxValue);
        dist[src] = 0;

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(src, 0);

        while (pq.Count > 0) {
            pq.TryDequeue(out int u, out int d);
            if (d > dist[u]) continue;

            foreach (var (v, w) in graph[u]) {
                int nd = d + w;
                if (nd < dist[v]) {
                    dist[v] = nd;
                    pq.Enqueue(v, nd);
                }
            }
        }
        return dist;
    }
}