using System.Text;

namespace DSAandAlgo.Strings;

/// <summary>
/// LeetCode 394 - Decode String.
/// Decode a run-length-encoded string of the form k[encoded_string], where
/// the encoded segment is repeated k times. Nesting is allowed.
/// </summary>
/// <example>
/// Input:  "3[a]2[bc]"     Output: "aaabcbc"
/// Input:  "3[a2[c]]"      Output: "accaccacc"
/// Input:  "2[abc]3[cd]ef" Output: "abcabccdcdcdef"
/// </example>
/// <remarks>
/// Approach: walk the string with two stacks - one for the multiplier counts
/// and one for the partial strings built so far. On '[' push the current
/// state; on ']' pop and apply the multiplier. O(n * maxK) time.
/// </remarks>
public class DecodeString
{
    public string Solve(string s)
    {
        var countStack = new Stack<int>();
        var stringStack = new Stack<StringBuilder>();
        var current = new StringBuilder();
        int count = 0;

        foreach (char c in s)
        {
            if (char.IsDigit(c))
            {
                count = count * 10 + (c - '0');
            }
            else if (c == '[')
            {
                countStack.Push(count);
                stringStack.Push(current);
                current = new StringBuilder();
                count = 0;
            }
            else if (c == ']')
            {
                int repeat = countStack.Pop();
                var previous = stringStack.Pop();
                for (int i = 0; i < repeat; i++)
                {
                    previous.Append(current);
                }
                current = previous;
            }
            else
            {
                current.Append(c);
            }
        }

        return current.ToString();
    }
}
