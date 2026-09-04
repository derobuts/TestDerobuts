namespace DSAandAlgo.Partition;

/// <summary>
/// LeetCode 131 - Palindrome Partitioning.
/// Partition the input string into substrings such that every substring is
/// a palindrome. Return every possible such partition.
/// </summary>
/// <example>
/// Input:  "aab"
/// Output: [["a","a","b"],["aa","b"]]
/// </example>
/// <example>
/// Input:  "a"
/// Output: [["a"]]
/// </example>
/// <remarks>
/// Approach: classic backtracking. At each position try every prefix that is
/// a palindrome, recurse on the rest, then undo. O(n * 2^n) in the worst case.
/// </remarks>
public class PalindromePartition
{
    public IList<IList<string>> Solve(string s)
    {
        var ans = new List<IList<string>>();
        Dfs(0, new List<string>(), s, ans);
        return ans;
    }

    private void Dfs(int start, List<string> currentList, string s, List<IList<string>> result)
    {
        if (start >= s.Length)
        {
            result.Add(new List<string>(currentList));
            return;
        }

        for (int end = start; end < s.Length; end++)
        {
            if (IsPalindrome(s, start, end))
            {
                currentList.Add(s.Substring(start, end - start + 1));
                Dfs(end + 1, currentList, s, result);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }

    private bool IsPalindrome(string s, int low, int high)
    {
        while (low < high)
            if (s[low++] != s[high--])
                return false;
        return true;
    }
}
