namespace DSAandAlgo.TwoPointer;

/// <summary>
/// LeetCode 283 - Move Zeroes.
/// Move every zero in the array to the end, preserving the order of the
/// non-zero elements. Mutates the array in place.
/// </summary>
/// <example>
/// Input:  [0,1,0,3,12]   Output: [1,3,12,0,0]
/// Input:  [0]            Output: [0]
/// </example>
/// <remarks>
/// Approach: two pointers. The "write" pointer advances only when we copy a
/// non-zero. After the first pass, zero-fill the tail. O(n) with each
/// non-zero touched once, vs. the O(n^2) bubble-style approach.
/// </remarks>
public class MoveZeroes
{
    public void Solve(int[] nums)
    {
        int write = 0;
        for (int read = 0; read < nums.Length; read++)
        {
            if (nums[read] != 0)
            {
                nums[write++] = nums[read];
            }
        }

        for (; write < nums.Length; write++)
        {
            nums[write] = 0;
        }
    }
}
