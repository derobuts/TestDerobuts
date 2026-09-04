using DSAandAlgo.Shared;

namespace DSAandAlgo.LineSweep;

/// <summary>
/// LeetCode 759 - Employee Free Time.
/// Given each employee's working intervals (sorted, non-overlapping per
/// employee), return the finite, positive-length intervals during which
/// every employee is free. Intervals that extend to +/- infinity are
/// excluded.
/// </summary>
/// <example>
/// Input:  [[[1,2],[5,6]],[[1,3]],[[4,10]]]   Output: [[3,4]]
/// Input:  [[[1,3],[6,7]],[[2,4]],[[2,5],[9,12]]]   Output: [[5,6],[7,9]]
/// </example>
/// <remarks>
/// Approach: emit (start, +1) and (end, -1) events across all employees,
/// sort with starts before ends at ties (so that contiguous coverage is
/// preserved), then walk events. A free interval opens when the active
/// counter drops to 0 and closes when it leaves 0 again.
/// </remarks>
public class EmployeeFreeTime
{
    public IList<Interval> Solve(IList<IList<Interval>> schedule) {
        var events = new List<(int time, int delta)>();
        foreach (var employee in schedule)
        foreach (var interval in employee) {
            events.Add((interval.start, +1));   // start → +1 worker
            events.Add((interval.end, -1));     // end → -1 worker
        }

        // tie-break: ends (-1) before starts (+1) → a.delta - b.delta
        events.Sort((a, b) => a.time == b.time ? a.delta - b.delta : a.time - b.time);

        var result = new List<Interval>();
        int active = 0;
        int prevEnd = -1;
        foreach (var (time, delta) in events) {
            if (active == 0 && prevEnd != -1 && prevEnd < time)
                result.Add(new Interval(prevEnd, time));   // free gap

            active += delta;                               // just SUM — no if/else
            if (delta == -1) prevEnd = time;               // track the last end
        }
        return result;
    }
}
