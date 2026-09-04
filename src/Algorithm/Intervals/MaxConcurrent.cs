namespace DSAandAlgo.Intervals;

public class MaxConcurrent
{
    public int MaxConcurrents(int[][] shifts)
    {
        var events = new List<(int time, int delta)>();
        foreach (var shift in shifts)
        {
            events.Add((shift[0], 1));
            events.Add((shift[1], -1));
        }
        
        events.Sort((a, b) => a.time == b.time ? a.delta - b.delta : a.time - b.time);

        int current = 0, peak = 0;
        foreach (var (time, delta) in events) {
            current += delta;
            peak = Math.Max(peak, current);
        }
        return peak;
    }
}