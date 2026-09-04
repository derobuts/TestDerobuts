namespace DSAandAlgo.HashTable;

/// <summary>
/// LeetCode 13 - Roman to Integer.
/// Convert a Roman numeral string to its integer value. The input is in the
/// range [1, 3999]. Subtractive pairs (IV, IX, XL, XC, CD, CM) represent
/// 4, 9, 40, 90, 400, 900 respectively.
/// </summary>
/// <example>
/// Input: "III"      Output: 3
/// Input: "IV"       Output: 4
/// Input: "LVIII"    Output: 58
/// Input: "MCMXCIV"  Output: 1994
/// </example>
/// <remarks>
/// Approach: scan left-to-right. If the current symbol is smaller than the
/// next, subtract (consuming two symbols); otherwise add. O(n).
/// </remarks>
public class RomanToInt
{
    private static readonly Dictionary<char, int> Values = new()
    {
        { 'I', 1 }, { 'V', 5 }, { 'X', 10 },
        { 'L', 50 }, { 'C', 100 }, { 'D', 500 },
        { 'M', 1000 }
    };

    public int Solve(string s)
    {
        int total = 0;
        int i = 0;
        while (i < s.Length)
        {
            int currentValue = Values[s[i]];
            int nextValue = (i + 1 < s.Length) ? Values[s[i + 1]] : 0;

            if (currentValue < nextValue)
            {
                total += nextValue - currentValue;
                i += 2;
            }
            else
            {
                total += currentValue;
                i += 1;
            }
        }

        return total;
    }
}
