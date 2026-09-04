namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 1882 - Process Tasks Using Servers.
/// You have <c>n</c> servers (each with a weight) and <c>m</c> tasks. Task j
/// arrives at time j (0-indexed) and takes <c>tasks[j]</c> seconds. When a
/// task arrives, it is given to the free server with the smallest (weight,
/// index); if no server is free, the task waits until one becomes free.
/// Return an array where <c>ans[j]</c> is the server that runs task j.
/// </summary>
/// <example>
/// Input:  servers=[3,3,2], tasks=[1,2,3,2,1,2] 
/// Output: [2,2,0,2,1,2]
/// </example>
/// <remarks>
/// Approach: two priority queues - free servers keyed by (weight, index), and
/// busy servers keyed by (endTime, weight, index). For each task we move all
/// servers that have finished by current time back to free; if free is empty
/// we fast-forward time to the next finish. O((n + m) log n).
/// </remarks>
public class AssignTasks
{
    public int[] Solve(int[] servers, int[] tasks)
    {
        int[] result = new int[tasks.Length];

        var free = new PriorityQueue<int, (int weight, int idx)>();
        for (int i = 0; i < servers.Length; i++)
        {
            free.Enqueue(i, (servers[i], i));
        }

        var busy = new PriorityQueue<int, (long end, int weight, int idx)>();
        long time = 0;

        for (int j = 0; j < tasks.Length; j++)
        {
            time = Math.Max(time, j);

            while (busy.Count > 0 && busy.TryPeek(out int s, out var p) && p.end <= time)
            {
                busy.Dequeue();
                free.Enqueue(s, (servers[s], s));
            }

            int chosen;
            long endTime;

            if (free.Count > 0)
            {
                chosen = free.Dequeue();
                endTime = time + tasks[j];
            }
            else
            {
                busy.TryDequeue(out chosen, out var next);
                time = next.end;
                endTime = next.end + tasks[j];
            }

            result[j] = chosen;
            busy.Enqueue(chosen, (endTime, servers[chosen], chosen));
        }

        return result;
    }
}
