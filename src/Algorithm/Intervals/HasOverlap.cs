namespace DSAandAlgo.Intervals;

public class HasOverlap
{
    public bool HasOverlaps(int[][] shifts)
    {
        Array.Sort(shifts, (a, b) => a[0] - b[0]);
        for (int i = 1; i < shifts.Length; i++)
        {
            if (shifts[i][1] < shifts[i - 1][0])
            {
                return true;
            }
        }
        return false;
    }
}