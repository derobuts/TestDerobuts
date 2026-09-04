namespace DSAandAlgo.TwoPointer;

/// <summary>
/// LeetCode 42 - Trapping Rain Water.
/// Given an elevation map <c>height</c>, compute how much rain water can be
/// trapped between the bars.
/// </summary>
/// <example>
/// Input:  [0,1,0,2,1,0,1,3,2,1,2,1]   Output: 6
/// Input:  [4,2,0,3,2,5]               Output: 9
/// </example>
/// <remarks>
/// Approach: two pointers moving inward, plus running max heights on each
/// side. At each step, water level above a bar is determined by the smaller
/// of the two running maxes; advance the pointer on the side with the
/// smaller running max because that side bounds the trapped water there.
/// O(n) time, O(1) extra space.
/// </remarks>
public class Trap
{
    public int Solve(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        int total = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax) leftMax = height[left];
                else total += leftMax - height[left];
                left++;
            }
            else
            {
                if (height[right] >= rightMax) rightMax = height[right];
                else total += rightMax - height[right];
                right--;
            }
        }

        return total;
    }
}
