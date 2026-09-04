namespace DSAandAlgo.MonotonicStack;

/// <summary>
/// LeetCode 321 - Create Maximum Number (single-array helper).
/// Given <c>nums</c> and a target length <c>k</c>, return the largest
/// possible <c>k</c>-digit subsequence of <c>nums</c> preserving order.
/// This is the helper used by LeetCode 321's full solution.
/// </summary>
/// <example>
/// Input:  nums=[3,4,6,5], k=2   Output: [6,5]
/// Input:  nums=[9,1,2,5,8,3], k=3   Output: [9,8,3]
/// </example>
/// <remarks>
/// Approach: monotonic decreasing stack. For each incoming digit, pop the
/// top as long as it's smaller, the stack is non-empty, and we still have
/// digits we can afford to drop. Trim any extras at the end. O(n).
/// </remarks>
public class MaxNumber
{
    public int[] Solve(int[] nums, int k)
    {
        if (k == 0) return Array.Empty<int>();

        int drop = nums.Length - k;
        var stack = new Stack<int>();

        foreach (int num in nums)
        {
            while (drop > 0 && stack.Count > 0 && stack.Peek() < num)
            {
                stack.Pop();
                drop--;
            }
            stack.Push(num);
        }

        while (stack.Count > k) stack.Pop();

        var result = new int[k];
        for (int i = k - 1; i >= 0; i--)
        {
            result[i] = stack.Pop();
        }
        return result;
    }
}
