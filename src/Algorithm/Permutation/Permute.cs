namespace DSAandAlgo.Permutation;

/// <summary>
/// LeetCode 46 - Permutations.
/// Given an array of distinct integers, return every possible permutation.
/// The order of permutations in the output does not matter.
/// </summary>
/// <example>
/// Input:  [1,2,3]
/// Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
/// </example>
/// <example>
/// Input:  [0,1]   Output: [[0,1],[1,0]]
/// </example>
/// <remarks>
/// Approach: classic backtracking. Maintain a "used" flag per index; at each
/// depth pick any unused element, recurse, undo. O(n * n!).
/// </remarks>
public class Permute
{
    public IList<IList<int>> Solve(int[] nums)
    {
        var result = new List<IList<int>>();
        var used = new bool[nums.Length];
        Backtrack(nums, used, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] nums, bool[] used, List<int> current, List<IList<int>> result)
    {
        if (current.Count == nums.Length)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue;

            used[i] = true;
            current.Add(nums[i]);
            Backtrack(nums, used, current, result);
            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}
