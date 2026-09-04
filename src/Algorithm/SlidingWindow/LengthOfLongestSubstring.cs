namespace DSAandAlgo.SlidingWindow;

/// <summary>
/// LeetCode 3 - Longest Substring Without Repeating Characters.
/// Return the length of the longest substring of <c>s</c> that contains no
/// character more than once.
/// </summary>
/// <example>
/// Input: "abcabcbb"   Output: 3   ("abc")
/// Input: "bbbbb"      Output: 1   ("b")
/// Input: "pwwkew"     Output: 3   ("wke")
/// Input: ""           Output: 0
/// </example>
/// <remarks>
/// Approach: expanding/contracting sliding window with a HashSet of chars
/// in the window. When we hit a duplicate, shrink from the left until the
/// duplicate is gone. O(n).
/// </remarks>
public class LengthOfLongestSubstring
{
    public int Solve(string s)
    {
        int left = 0, max = 0;
        var seen = new HashSet<char>();

        for (int right = 0; right < s.Length; right++)
        {
            while (seen.Contains(s[right]))
            {
                seen.Remove(s[left]);
                left++;
            }
            seen.Add(s[right]);
            max = Math.Max(max, right - left + 1);
        }

        return max;
    }
}
