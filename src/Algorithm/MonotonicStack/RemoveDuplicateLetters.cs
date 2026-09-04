using System.Text;

namespace DSAandAlgo.MonotonicStack;

/// <summary>
/// LeetCode 316 - Remove Duplicate Letters.
/// Given a string, remove duplicate letters so that every letter appears
/// once, and the result is the lexicographically smallest among all valid
/// outputs.
/// </summary>
/// <example>
/// Input: "bcabc"    Output: "abc"
/// Input: "cbacdcbc" Output: "acdb"
/// </example>
/// <remarks>
/// Approach: monotonic stack with a "last index" lookup. For each char c,
/// pop characters on top of the stack that are greater than c AND still
/// appear later in the string (we can safely defer them). Skip chars
/// already in the stack. O(n).
/// </remarks>
public class RemoveDuplicateLetters
{
    public string Solve(string s)
    {
        var lastIndex = new int[26];
        var inStack = new bool[26];
        var stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            lastIndex[s[i] - 'a'] = i;
        }

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            int idx = c - 'a';

            if (inStack[idx]) continue;

            while (stack.Count > 0 && c < stack.Peek() && lastIndex[stack.Peek() - 'a'] > i)
            {
                inStack[stack.Pop() - 'a'] = false;
            }

            stack.Push(c);
            inStack[idx] = true;
        }

        var sb = new StringBuilder();
        while (stack.Count > 0) sb.Insert(0, stack.Pop());

        return sb.ToString();
    }
}
