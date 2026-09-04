namespace DSAandAlgo.Dijkstra;

public class NetworkDelay
{
    public int NetworkDelayTime(int[][] times, int n, int k) {
        // build adjacency list — nodes are 1-indexed, so size n+1
        var graph = new List<(int node, int weight)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int, int)>();

        foreach (var t in times)
        {
            graph[t[0]].Add((t[1], t[2]));      // directed edge u → v, weight w   
        }

        // Dijkstra from k
        var dist = new int[n + 1];
        Array.Fill(dist, int.MaxValue);
        dist[k] = 0;

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, 0);

        while (pq.Count > 0) {
            pq.TryDequeue(out int u, out int d);
            if (d > dist[u]) continue;                  // stale entry

            foreach (var (v, w) in graph[u]) {
                int nd = d + w;
                if (nd < dist[v]) {
                    dist[v] = nd;
                    pq.Enqueue(v, nd);
                }
            }
        }

        // the signal arrives when the FARTHEST node receives it
        int max = 0;
        for (int i = 1; i <= n; i++) {
            if (dist[i] == int.MaxValue) return -1;     // unreachable node
            max = Math.Max(max, dist[i]);
        }
        return max;
    }
}