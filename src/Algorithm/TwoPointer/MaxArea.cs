namespace DSAandAlgo.TwoPointer;

/// <summary>
/// LeetCode 11 - Container With Most Water.
/// Given an array <c>height</c> where height[i] is a vertical line at
/// position i, find two lines that, together with the x-axis, form a
/// container holding the most water. Return the largest area.
/// </summary>
/// <example>
/// Input:  [1,8,6,2,5,4,8,3,7]   Output: 49
/// Input:  [1,1]                  Output: 1
/// </example>
/// <remarks>
/// Approach: two pointers at the ends. The area is bounded by the shorter
/// line, so move whichever pointer is at the shorter line inward - the
/// other end can only improve if we find a taller line. O(n).
/// </remarks>
public class MaxArea
{
    public int Solve(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int max = 0;

        while (left < right)
        {
            int h = Math.Min(height[left], height[right]);
            int w = right - left;
            max = Math.Max(max, h * w);

            if (height[left] < height[right]) left++;
            else right--;
        }

        return max;
    }
}
