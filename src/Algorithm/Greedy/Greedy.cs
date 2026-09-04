namespace DSAandAlgo.Greedy;

public class Greedy
{
    // Problem: Given n activities with start and end times, select the maximum number of non-overlapping activities.
    public int MaxNoActivities(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int count = 1;
        int lastEnd = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] >= lastEnd)
            {
                count++;
                lastEnd = intervals[i][1];
            }
        }
        return count;
    }
}