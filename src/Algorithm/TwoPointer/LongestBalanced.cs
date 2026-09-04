namespace DSAandAlgo.TwoPointer;

/// <summary>
/// LeetCode 525 - Contiguous Array.
/// Given a binary array (only 0s and 1s), return the length of the longest
/// contiguous subarray with an equal number of 0s and 1s.
/// </summary>
/// <example>
/// Input:  [0,1]         Output: 2
/// Input:  [0,1,0]       Output: 2
/// Input:  [0,0,1,0,0,0,1,1]   Output: 6
/// </example>
/// <remarks>
/// Approach: treat 0 as -1 and walk a running sum. A subarray has equal
/// counts iff its sum is 0, equivalently the prefix sums at its endpoints
/// are equal. Keep a dictionary mapping prefix-sum to its earliest index;
/// for each i, the longest valid subarray ending at i has length
/// <c>i - earliest(prefixSum[i])</c>. O(n).
/// </remarks>
public class LongestBalanced
{
    public int Solve(int[] nums)
    {
        var firstSeen = new Dictionary<int, int> { { 0, -1 } };
        int sum = 0;
        int best = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i] == 1 ? 1 : -1;

            if (firstSeen.TryGetValue(sum, out int earliest))
            {
                best = Math.Max(best, i - earliest);
            }
            else
            {
                firstSeen[sum] = i;
            }
        }

        return best;
    }
}
