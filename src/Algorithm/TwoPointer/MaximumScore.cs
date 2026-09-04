namespace DSAandAlgo.TwoPointer;

/// <summary>
/// LeetCode 1793 - Maximum Score of a Good Subarray.
/// A "good" subarray is one that contains index <c>k</c>. Its score is
/// <c>min(subarray) * length(subarray)</c>. Return the maximum score over
/// all good subarrays.
/// </summary>
/// <example>
/// Input:  nums=[1,4,3,7,4,5], k=3   Output: 15
/// Input:  nums=[5,5,4,5,4,1,1,1], k=0   Output: 20
/// </example>
/// <remarks>
/// Approach: start with the window [k, k] and expand outward. At each step
/// extend the side whose neighbour is larger - keeping the current minimum
/// of the window as high as possible. The minimum is non-increasing as we
/// expand, so multiply it by the current width and track the best. O(n).
/// </remarks>
public class MaximumScore
{
    public int Solve(int[] nums, int k)
    {
        int left = k, right = k;
        int min = nums[k];
        int best = min;

        while (left > 0 || right < nums.Length - 1)
        {
            int leftVal = left > 0 ? nums[left - 1] : int.MinValue;
            int rightVal = right < nums.Length - 1 ? nums[right + 1] : int.MinValue;

            if (leftVal >= rightVal) left--;
            else right++;

            min = Math.Min(min, Math.Min(left >= 0 ? nums[left] : int.MaxValue, right < nums.Length ? nums[right] : int.MaxValue));
            best = Math.Max(best, min * (right - left + 1));
        }

        return best;
    }
}
