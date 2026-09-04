namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 252 - Meeting Rooms.
/// Given an array of meeting time intervals where intervals[i] = [start, end],
/// determine if a single person could attend all meetings (i.e. no two
/// meetings overlap). Treat intervals as half-open: a meeting ending at t
/// does not conflict with another starting at t.
/// </summary>
/// <example>
/// Input:  [[0,30],[5,10],[15,20]]   Output: false
/// Input:  [[7,10],[2,4]]            Output: true
/// </example>
/// <remarks>
/// Approach: sort by start time, then check adjacent pairs. O(n log n).
/// </remarks>
public class CanAttendMeetings
{
    public bool Solve(int[][] intervals)
    {
        if (intervals.Length <= 1) return true;

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] < intervals[i - 1][1])
            {
                return false;
            }
        }

        return true;
    }
}
