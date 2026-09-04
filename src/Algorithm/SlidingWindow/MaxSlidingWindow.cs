namespace DSAandAlgo.SlidingWindow;

/// <summary>
/// LeetCode 239 - Sliding Window Maximum.
/// Given an array and a window size <c>k</c>, return the maximum of each
/// window of <c>k</c> consecutive elements.
/// </summary>
/// <example>
/// Input:  nums=[1,3,-1,-3,5,3,6,7], k=3
/// Output: [3,3,5,5,6,7]
/// </example>
/// <remarks>
/// Approach: monotonic deque storing indices in decreasing-value order. As
/// the window slides we (a) drop the front if it falls out of the window
/// and (b) drop the back while it is smaller than the incoming element.
/// The front of the deque is always the maximum of the current window.
/// O(n).
/// </remarks>
public class MaxSlidingWindow
{
    public int[] Solve(int[] nums, int k)
    {
        int n = nums.Length;
        if (n == 0 || k == 0) return Array.Empty<int>();

        var result = new int[n - k + 1];
        var deque = new LinkedList<int>();

        for (int i = 0; i < n; i++)
        {
            if (deque.Count > 0 && deque.First!.Value <= i - k)
            {
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && nums[deque.Last!.Value] < nums[i])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);

            if (i >= k - 1)
            {
                result[i - k + 1] = nums[deque.First!.Value];
            }
        }

        return result;
    }
}
