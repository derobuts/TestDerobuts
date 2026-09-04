namespace DSAandAlgo.SlidingWindow;

/// <summary>
/// LeetCode 76 - Minimum Window Substring.
/// Given strings <c>s</c> and <c>t</c>, return the shortest substring of
/// <c>s</c> that contains every character of <c>t</c> (including
/// multiplicities). Return "" if no such window exists.
/// </summary>
/// <example>
/// Input:  s="ADOBECODEBANC", t="ABC"   Output: "BANC"
/// Input:  s="a", t="a"                 Output: "a"
/// Input:  s="a", t="aa"                Output: ""
/// </example>
/// <remarks>
/// Approach: classic two-pointer sliding window. Maintain a required-count
/// map for <c>t</c> and a "missing" counter. Expand the right pointer
/// until the window covers <c>t</c>, then contract from the left to find
/// the smallest such window before continuing. O(|s| + |t|).
/// </remarks>
public class MinWindow
{
    public string Solve(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";
        if (t.Length > s.Length) return "";

        var need = new int [128];
        var currentwindow = new int [128];

        int required = 0;
        foreach (var c in  t)
        {
            if (need[c] == 0)
            {
                required++;
                need[c]++;
            }
        }
        // l
        for (int right = 0; right < s.Length; right++)
        {
            // expand
            char c = s[right];
            currentwindow[c]++;
        }
    }
}
