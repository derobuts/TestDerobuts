using System.Text;

namespace DSAandAlgo.MonotonicStack;

/// <summary>
/// LeetCode 402 - Remove K Digits.
/// Given a non-negative integer represented as a string and an integer
/// <c>k</c>, remove exactly <c>k</c> digits so the resulting number is the
/// smallest possible. Leading zeros are stripped; if the result is empty
/// return "0".
/// </summary>
/// <example>
/// Input:  num="1432219", k=3   Output: "1219"
/// Input:  num="10200",  k=1    Output: "200"
/// Input:  num="10",     k=2    Output: "0"
/// </example>
/// <remarks>
/// Approach: monotonic increasing stack of characters. For each digit, pop
/// while the top is greater and we still need to remove digits. If we end
/// with budget left, pop from the back. Strip leading zeros. O(n).
/// </remarks>
public class LexSmallestAfterDeletion
{
    public string Solve(string num, int k)
    {
        if (k >= num.Length) return "0";

        var stack = new Stack<char>();

        foreach (char c in num)
        {
            while (stack.Count > 0 && k > 0 && stack.Peek() > c)
            {
                stack.Pop();
                k--;
            }
            stack.Push(c);
        }

        while (k-- > 0 && stack.Count > 0) stack.Pop();

        var sb = new StringBuilder();
        while (stack.Count > 0) sb.Insert(0, stack.Pop());

        int start = 0;
        while (start < sb.Length - 1 && sb[start] == '0') start++;
        return sb.ToString(start, sb.Length - start);
    }
}
