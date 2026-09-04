namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 1751 - Maximum Number of Events That Can Be Attended II.
/// Given events [start, end, value] and a budget <c>k</c>, attend at most
/// <c>k</c> non-overlapping events to maximize total value. End-day is
/// inclusive, so two events sharing a boundary conflict.
/// </summary>
/// <example>
/// Input:  events=[[1,2,4],[3,4,3],[2,3,1]], k=2
/// Output: 7
/// </example>
/// <remarks>
/// Approach: recursive "take or skip" backtracking. The optimized version
/// would memoize on (index, count) and binary-search for the next non-
/// overlapping event after picking one, giving O(n log n * k).
/// </remarks>
public class MaxValue
{
    public int Solve(int[][] events, int k)
    {
        Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));
        return Backtrack(events, k, 0, 0, -1);
    }

    private int Backtrack(int[][] events, int k, int index, int count, int lastEnd)
    {
        if (count == k || index == events.Length) return 0;

        int skip = Backtrack(events, k, index + 1, count, lastEnd);

        int attend = 0;
        if (events[index][0] > lastEnd)
        {
            attend = events[index][2] + Backtrack(events, k, index + 1, count + 1, events[index][1]);
        }

        return Math.Max(skip, attend);
    }
}
