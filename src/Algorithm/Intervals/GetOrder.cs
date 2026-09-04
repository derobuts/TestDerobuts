namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 1834 - Single-Threaded CPU.
/// Each task is <c>[enqueueTime, processingTime]</c>. A single CPU picks the
/// available task with the smallest processing time (ties broken by index)
/// whenever it is idle, and runs it to completion before choosing the next.
/// If no tasks are available the CPU idles until the next task arrives.
/// Return the order in which tasks finish.
/// </summary>
/// <example>
/// Input:  [[1,2],[2,4],[3,2],[4,1]]
/// Output: [0,2,3,1]
/// </example>
/// <remarks>
/// Approach: sort task indices by enqueueTime; maintain a min-heap of
/// available tasks keyed by (processingTime, index). Advance a "now" clock,
/// admit all tasks with enqueueTime &lt;= now into the heap, then pop the
/// next to run. O(n log n).
/// </remarks>
public class  GetOrder
{
    public int[] Solve(int[][] tasks)
    {
        int n = tasks.Length;
        var indices = Enumerable.Range(0, n).ToArray();
        Array.Sort(indices, (a, b) => tasks[a][0].CompareTo(tasks[b][0]));

        var available = new PriorityQueue<int, (int processing, int idx)>();
        var order = new int[n];
        long now = 0;
        int next = 0;
        int filled = 0;

        while (filled < n)
        {
            if (available.Count == 0 && next < n && tasks[indices[next]][0] > now)
            {
                now = tasks[indices[next]][0];
            }

            while (next < n && tasks[indices[next]][0] <= now)
            {
                int idx = indices[next++];
                available.Enqueue(idx, (tasks[idx][1], idx));
            }

            int chosen = available.Dequeue();
            now += tasks[chosen][1];
            order[filled++] = chosen;
        }

        return order;
    }
}
