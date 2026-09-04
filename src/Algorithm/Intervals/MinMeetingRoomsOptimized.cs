namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 253 - Meeting Rooms II (min-heap solution).
/// Given meeting intervals [start, end], return the minimum number of
/// conference rooms required to host all of them without conflict.
/// </summary>
/// <example>
/// Input:  [[0,30],[5,10],[15,20]]   Output: 2
/// Input:  [[7,10],[2,4]]            Output: 1
/// </example>
/// <remarks>
/// Approach: sort meetings by start. Use a min-heap of end-times of currently
/// occupied rooms. For each meeting, if the earliest-ending room frees up
/// before it starts, reuse that room; otherwise allocate a new one. The
/// heap size at the end of the loop is the answer. O(n log n).
/// </remarks>
public class MinMeetingRoomsOptimized
{
    public int Solve(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var endTimes = new PriorityQueue<int, int>();
        endTimes.Enqueue(intervals[0][1], intervals[0][1]);

        for (int i = 1; i < intervals.Length; i++)
        {
            if (endTimes.Peek() <= intervals[i][0])
            {
                endTimes.Dequeue();
            }
            endTimes.Enqueue(intervals[i][1], intervals[i][1]);
        }

        return endTimes.Count;
    }
}
