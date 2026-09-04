namespace DSAandAlgo.Partition;

/// <summary>
/// LeetCode 132 - Palindrome Partitioning II.
/// Return the minimum number of cuts needed to partition <c>s</c> so that
/// every resulting substring is a palindrome.
/// </summary>
/// <example>
/// Input:  "aab"   Output: 1   ("aa" | "b")
/// Input:  "a"     Output: 0
/// Input:  "ab"    Output: 1
/// </example>
/// <remarks>
/// Approach: DP. First precompute <c>isPalindrome[i,j]</c>. Then let
/// <c>cuts[i]</c> be the min cuts for s[0..i]. For each i, scan back to j
/// and if s[j..i] is a palindrome, cuts[i] = min(cuts[i], cuts[j-1] + 1)
/// (or 0 when j == 0). O(n^2) time and space.
/// </remarks>
public class MinCut
{
    public int Solve(string s)
    {
        int n = s.Length;
        if (n <= 1) return 0;

        bool[,] isPalindrome = new bool[n, n];
        for (int i = 0; i < n; i++) isPalindrome[i, i] = true;

        for (int length = 2; length <= n; length++)
        {
            for (int i = 0; i + length <= n; i++)
            {
                int j = i + length - 1;
                if (s[i] == s[j] && (length == 2 || isPalindrome[i + 1, j - 1]))
                {
                    isPalindrome[i, j] = true;
                }
            }
        }

        int[] cuts = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (isPalindrome[0, i])
            {
                cuts[i] = 0;
                continue;
            }

            cuts[i] = int.MaxValue;
            for (int j = 1; j <= i; j++)
            {
                if (isPalindrome[j, i])
                {
                    cuts[i] = Math.Min(cuts[i], cuts[j - 1] + 1);
                }
            }
        }

        return cuts[n - 1];
    }
}
