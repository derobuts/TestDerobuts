namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 1607 - Find Servers That Handled Most Number of Requests.
/// You have <c>k</c> servers numbered 0..k-1 and a list of requests with
/// arrival times and loads. Request i is dispatched to server
/// <c>(i mod k)</c>, or to the next free server scanning forward (with wrap)
/// from that index. If all servers are busy the request is dropped. Return
/// the indices of servers that handled the most requests.
/// </summary>
/// <example>
/// Input:  k=3, arrival=[1,2,3,4,5], load=[5,2,3,3,3]
/// Output: [1]
/// </example>
/// <remarks>
/// Approach (brute-force): track per-server end time and request count, scan
/// forward from (i mod k) for each request. O(n * k). For larger k use a
/// sorted-set of free servers + heap of busy ones for O((n + k) log k).
/// </remarks>
public class BusiestServers
{
    public IList<int> BruteForceSolve(int k, int[] arrival, int[] load)
    {
        int[] endTimes = new int[k];
        int[] count = new int[k];

        for (int i = 0; i < arrival.Length; i++)
        {
            for (int s = 0; s < k; s++)
            {
                int server = (i + s) % k;

                if (endTimes[server] <= arrival[i])
                {
                    endTimes[server] = arrival[i] + load[i];
                    count[server]++;
                    break;
                }
            }
        }

        int max = count.Max();
        var servers = new List<int>();

        for (int i = 0; i < k; i++)
        {
            if (count[i] == max) servers.Add(i);
        }

        return servers;
    }

    public IList<int> Solve(int k, int[] arrival, int[] load)
    {
        var pr = new PriorityQueue<int, int>();
        return null;
    }
}
