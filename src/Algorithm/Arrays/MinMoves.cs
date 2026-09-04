namespace DSAandAlgo.Arrays;

public class MinMoves
{
    public int MinMoves2(int[] nums) {
        int maxSum = int.MinValue;
        for (int i = 0; i < nums.Length; i++)
        {
            int target = nums[i];
            int moves = 0;
            foreach (var n in nums)
            {
                moves += Math.Abs(n - target);
            }
            maxSum = Math.Max(maxSum, moves);
        }
        return maxSum;
    }
}