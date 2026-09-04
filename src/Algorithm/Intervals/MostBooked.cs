namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 2402 - Meeting Rooms III.
/// You have <c>n</c> rooms numbered 0..n-1 and a list of meetings
/// [start, end). Allocation rules:
/// <list type="bullet">
///   <item>Each meeting goes to the available room with the lowest number.</item>
///   <item>If all rooms are busy, the meeting is delayed (keeping its original duration) and uses the first room to free up.</item>
///   <item>Among delayed meetings, the one with the smaller original start runs first.</item>
/// </list>
/// Return the room that hosted the most meetings; ties go to the lowest number.
/// </summary>
/// <example>
/// Input:  n=2, meetings=[[0,10],[1,5],[2,7],[3,4]]
/// Output: 0
/// </example>
/// <remarks>
/// Approach: two heaps - <c>available</c> keyed by room number, <c>busy</c>
/// keyed by (endTime, roomNumber). Process meetings in start order; release
/// rooms whose end &lt;= meeting.start, then allocate from available or fast-
/// forward time to the earliest finisher. O(m log (m + n)).
/// </remarks>
public class MostBooked
{
    public int Solve(int n, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        var available = new PriorityQueue<int, int>();
        for (int i = 0; i < n; i++) 
            available.Enqueue(i, i);

        var busy = new PriorityQueue<(int room, long end), (long end, int room)>();
        var counts = new int[n];

        foreach (var meeting in meetings)
        {
            long start = meeting[0];
            long duration = meeting[1] - meeting[0];

            while (busy.Count > 0 && busy.Peek().end <= start)
            {
                var (room, _) = busy.Dequeue();
                available.Enqueue(room, room);
            }

            if (available.Count > 0)
            {
                int room = available.Dequeue();
                counts[room]++;
                busy.Enqueue((room, start + duration), (start + duration, room));
            }
            else
            {
                var (room, end) = busy.Dequeue();
                counts[room]++;
                busy.Enqueue((room, end + duration), (end + duration, room));
            }
        }

        int best = 0;
        for (int i = 1; i < n; i++)
        {
            if (counts[i] > counts[best]) best = i;
        }
        return best;
    }
}
