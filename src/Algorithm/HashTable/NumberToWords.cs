namespace DSAandAlgo.HashTable;

/// <summary>
/// LeetCode 273 - Integer to English Words.
/// Convert a non-negative integer (up to 2^31 - 1) into its English-words
/// representation. Words are separated by single spaces, with no trailing
/// or leading whitespace.
/// </summary>
/// <example>
/// Input: 123        Output: "One Hundred Twenty Three"
/// Input: 12345      Output: "Twelve Thousand Three Hundred Forty Five"
/// Input: 1234567    Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
/// </example>
/// <remarks>
/// Approach: split into groups of three digits from the right and label each
/// chunk with "Thousand"/"Million"/"Billion". Each chunk is at most 999 and
/// is converted recursively. Zero is the special case "Zero".
/// </remarks>
public class NumberToWords
{
    private static readonly string[] BelowTwenty =
    {
        "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
        "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
        "Sixteen", "Seventeen", "Eighteen", "Nineteen"
    };

    private static readonly string[] Tens =
    {
        "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
        "Eighty", "Ninety"
    };

    private static readonly string[] Thousands = { "", "Thousand", "Million", "Billion" };

    public string Solve(int num)
    {
        if (num == 0) return "Zero";

        string words = "";
        int i = 0;
        while (num > 0)
        {
            if (num % 1000 != 0)
            {
                string chunk = ThreeDigits(num % 1000).Trim();
                words = (chunk + " " + Thousands[i] + " " + words).Trim();
            }
            num /= 1000;
            i++;
        }

        return CollapseSpaces(words);
    }

    private string ThreeDigits(int n)
    {
        if (n == 0) return "";
        if (n < 20) return BelowTwenty[n] + " ";
        if (n < 100) return Tens[n / 10] + " " + ThreeDigits(n % 10);
        return BelowTwenty[n / 100] + " Hundred " + ThreeDigits(n % 100);
    }

    private static string CollapseSpaces(string s) =>
        string.Join(" ", s.Split(' ', StringSplitOptions.RemoveEmptyEntries));
}
