namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 253 - Meeting Rooms II (brute-force room-tracking solution).
/// Given meeting intervals [start, end], return the minimum number of
/// conference rooms required to host all of them without conflict.
/// </summary>
/// <example>
/// Input:  [[0,30],[5,10],[15,20]]   Output: 2
/// Input:  [[7,10],[2,4]]            Output: 1
/// </example>
/// <remarks>
/// Approach: keep a list of room end-times. For each meeting (in input order),
/// reuse the first room whose end-time is &lt;= the meeting's start; otherwise
/// open a new room. O(n^2) - simple but slow. See
/// <see cref="MinMeetingRoomsOptimized"/> for the O(n log n) heap version.
/// </remarks>
public class MinMeetingRoomsBruteForce
{
    public int Solve(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        var rooms = new List<int>();

        foreach (var meeting in intervals)
        {
            bool found = false;

            for (int i = 0; i < rooms.Count; i++)
            {
                if (meeting[0] >= rooms[i])
                {
                    rooms[i] = meeting[1];
                    found = true;
                    break;
                }
            }

            if (!found)
                rooms.Add(meeting[1]);
        }

        return rooms.Count;
    }
}
