using DSAandAlgo.Shared;

namespace DSAandAlgo.Dfs;

/// <summary>
/// LeetCode 339 - Nested List Weight Sum.
/// Each element in the list is either an integer or another nested list.
/// Each integer is weighted by its depth (top level is 1). Return the sum
/// of every integer multiplied by its depth.
/// </summary>
/// <example>
/// Input:  [[1,1],2,[1,1]]
/// Output: 10   (four 1s at depth 2 + one 2 at depth 1 = 4 * 1 * 2 + 2 = 10)
/// </example>
/// <example>
/// Input:  [1,[4,[6]]]
/// Output: 27   (1*1 + 4*2 + 6*3)
/// </example>
/// <remarks>
/// Approach: straight-forward DFS carrying the current depth. O(n) where n
/// is the total number of integers across all levels.
/// </remarks>
public class DepthSum
{
    public int Solve(IList<NestedInteger> nestedList)
    {
        return Dfs(nestedList, 1);
    }

    private int Dfs(IList<NestedInteger> nestedList, int depth)
    {
        int sum = 0;
        foreach (var nested in nestedList)
        {
            if (nested.IsInteger())
            {
                sum += nested.GetInteger() * depth;
            }
            else
            {
                sum += Dfs(nested.GetList(), depth + 1);
            }
        }
        return sum;
    }
}
