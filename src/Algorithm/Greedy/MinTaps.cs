namespace DSAandAlgo.Greedy;

public class MinTaps
{
    /**
     Minimum Number of Taps to Open to Water a Garden
    Hard
        Topics
    conpanies icon
    Companies
        Hint
    There is a one-dimensional garden on the x-axis. The garden starts at the point 0 and ends at the point n. (i.e., the length of the garden is n).

    There are n + 1 taps located at points [0, 1, ..., n] in the garden.

        Given an integer n and an integer array ranges of length n + 1 where ranges[i] (0-indexed) means the i-th tap can water the area [i - ranges[i], i + ranges[i]] if it was open.

        Return the minimum number of taps that should be open to water the whole garden, If the garden cannot be watered return -1.
     */
    public int MinTaps(int n, int[] ranges)
    {
        var maxReach = new int[n];
        for (int i = 0; i < ranges.Length; i++)
        {
            int start = Math.Max(0, i - ranges[i]);
            int end = Math.Min(n, i + ranges[i]);
            maxReach[start] = maxReach[start] = Math.Max(maxReach[start], end);
        }
        
        // sweep positions
        int count = 0, currentEnd = 0, fathest = 0;
        for (int i = 0; i < n; i++)
        {
            
        }
    }
}