namespace DSAandAlgo.Partition;

/// <summary>
/// Partition an array into <c>k</c> non-empty contiguous groups where every
/// element within a group has the same value. You may change any element to
/// any value; return the minimum number of changes required.
/// </summary>
/// <example>
/// Input:  arr=[1,1,2,2,3,3], k=3   Output: 0   (already three runs)
/// Input:  arr=[1,2,1,1,3],   k=2   Output: 1   ([1,1,1,1] | [3] after one change)
/// </example>
/// <remarks>
/// Approach: DP. <c>cost[i,j]</c> = minimum changes to make subarray
/// <c>arr[i..j]</c> all equal = (j - i + 1) - majority(arr[i..j]).
/// Then <c>dp[g, j]</c> = best way to split arr[0..j] into g groups:
/// dp[g, j] = min over split point i of dp[g-1, i-1] + cost[i, j]. O(n^2 * k).
/// </remarks>
public class MinimizeCost
{
    public int Solve(int[] arr, int k)
    {
        int n = arr.Length;
        if (k <= 0 || k > n) throw new ArgumentException("k must be in [1, n]");

        int[,] cost = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            var counts = new Dictionary<int, int>();
            int best = 0;
            for (int j = i; j < n; j++)
            {
                counts[arr[j]] = counts.GetValueOrDefault(arr[j]) + 1;
                if (counts[arr[j]] > best) best = counts[arr[j]];
                cost[i, j] = (j - i + 1) - best;
            }
        }

        int[,] dp = new int[k + 1, n];
        for (int j = 0; j < n; j++) dp[1, j] = cost[0, j];

        for (int g = 2; g <= k; g++)
        {
            for (int j = g - 1; j < n; j++)
            {
                int best = int.MaxValue;
                for (int i = g - 1; i <= j; i++)
                {
                    best = Math.Min(best, dp[g - 1, i - 1] + cost[i, j]);
                }
                dp[g, j] = best;
            }
        }

        return dp[k, n - 1];
    }
}
