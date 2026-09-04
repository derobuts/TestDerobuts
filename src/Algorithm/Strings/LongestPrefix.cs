namespace DSAandAlgo.Strings;

/// <summary>
/// LeetCode 1392 - Longest Happy Prefix.
/// A happy prefix is a non-empty prefix which is also a suffix (excluding the
/// whole string itself). Given a string <c>s</c>, return the longest happy
/// prefix of <c>s</c>, or "" if none exists.
/// </summary>
/// <example>
/// Input:  "level"     Output: "l"
/// Input:  "ababab"    Output: "abab"
/// Input:  "leetcode"  Output: ""
/// </example>
/// <remarks>
/// Two solutions are provided:
/// <list type="bullet">
///   <item><see cref="SolveBruteForce"/> - O(n^2) string compare, easy to read.</item>
///   <item><see cref="SolveRabinKarp"/>  - O(n) rolling hash, suitable for large n.</item>
/// </list>
/// </remarks>
public class LongestPrefix
{
    /// <summary>O(n^2) - compare every prefix to its matching-length suffix.</summary>
    public string SolveBruteForce(string s)
    {
        int n = s.Length;
        for (int len = n - 1; len > 0; len--)
        {
            string prefix = s.Substring(0, len);
            string suffix = s.Substring(n - len);
            if (prefix == suffix)
            {
                return prefix;
            }
        }
        return "";
    }

    /// <summary>
    /// O(n) - build prefix and suffix rolling hashes in lockstep. The longest
    /// length where the two hashes are equal is the answer.
    /// </summary>
    public string SolveRabinKarp(string s)
    {
        const long MOD = 1_000_000_007;
        const long BASE = 31;

        int n = s.Length;
        long prefixHash = 0;
        long suffixHash = 0;
        long power = 1;
        int maxLen = 0;

        for (int i = 0; i < n - 1; i++)
        {
            prefixHash = (prefixHash * BASE + (s[i] - 'a' + 1)) % MOD;
            suffixHash = (suffixHash + (s[n - 1 - i] - 'a' + 1) * power) % MOD;

            if (prefixHash == suffixHash)
            {
                maxLen = i + 1;
            }

            power = (power * BASE) % MOD;
        }

        return s.Substring(0, maxLen);
    }
}
