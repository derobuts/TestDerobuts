namespace DSAandAlgo.MonotonicStack;

/// <summary>
/// LeetCode 496 - Next Greater Element I.
/// <c>nums1</c> is a subset of <c>nums2</c>. For each element in
/// <c>nums1</c>, find the next greater element to its right in
/// <c>nums2</c>, or -1 if no such element exists.
/// </summary>
/// <example>
/// Input:  nums1=[4,1,2], nums2=[1,3,4,2]   Output: [-1,3,-1]
/// Input:  nums1=[2,4],   nums2=[1,2,3,4]   Output: [3,-1]
/// </example>
/// <remarks>
/// Approach: walk <c>nums2</c> right-to-left with a monotonic stack of
/// values (decreasing top-down). For each value, pop everything &lt;= it,
/// then the top of stack (if any) is its next-greater. Store result in a
/// dictionary keyed by value (works because nums2 values are distinct).
/// O(n + m).
/// </remarks>
public class NextGreaterElement
{
    public int[] Solve(int[] nums1, int[] nums2)
    {
        var nextGreater = new Dictionary<int, int>();
        var stack = new Stack<int>();

        for (int i = nums2.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && stack.Peek() <= nums2[i])
            {
                stack.Pop();
            }

            nextGreater[nums2[i]] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(nums2[i]);
        }

        var result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            result[i] = nextGreater[nums1[i]];
        }

        return result;
    }
}
