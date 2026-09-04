namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 1353 - Maximum Number of Events That Can Be Attended.
/// Each event spans <c>[startDay, endDay]</c> inclusive and you can attend
/// at most one event per day (any day in the event's range). Return the
/// maximum number of events that can be attended.
/// </summary>
/// <example>
/// Input:  [[1,2],[2,3],[3,4]]      Output: 3
/// Input:  [[1,2],[2,3],[3,4],[1,2]] Output: 4
/// </example>
/// <remarks>
/// Pattern: greedy interval scheduling. On each day, prefer the event whose
/// deadline is soonest. A min-heap of end days is the canonical O(n log n)
/// solution; the version below is the simpler O(n * d) sort-by-end variant
/// suitable for small day ranges.
/// </remarks>
public class MaxEvents
{
    public int Solve(int[][] events)
    {
        Array.Sort(events, (a, b) => a[1] - b[1]);
        var usedDays = new HashSet<int>();
        int count = 0;

        foreach (var e in events)
        {
            for (int d = e[0]; d <= e[1]; d++)
            {
                if (usedDays.Add(d))
                {
                    count++;
                    break;
                }
            }
        }

        return count;
    }
}
