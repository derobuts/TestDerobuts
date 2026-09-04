namespace DSAandAlgo.LineSweep;

/// <summary>
/// LeetCode 253 - Meeting Rooms II (line-sweep formulation).
/// Given meeting intervals [start, end], return the minimum number of
/// conference rooms required to host all of them without conflict.
/// </summary>
/// <example>
/// Input:  [[0,30],[5,10],[15,20]]   Output: 2
/// Input:  [[7,10],[2,4]]            Output: 1
/// </example>
/// <remarks>
/// Approach: emit +1 at every meeting start and -1 at every end; sort by
/// time, putting ends before starts at the same instant. Track the running
/// concurrency and take its max. O(n log n). See
/// <see cref="Intervals.MinMeetingRoomsOptimized"/> for the heap variant.
/// </remarks>
public class MinMeetingRooms
{
    public int Solve(int[][] intervals)
    {
        var events = new List<(int time, int delta)>();

        foreach (var interval in intervals)
        {
            events.Add((interval[0], +1));
            events.Add((interval[1], -1));
        }

        events.Sort((a, b) => a.time == b.time
            ? a.delta - b.delta
            : a.time - b.time);

        int active = 0, maxRooms = 0;

        foreach (var (_, delta) in events)
        {
            active += delta;
            maxRooms = Math.Max(maxRooms, active);
        }

        return maxRooms;
    }
}
