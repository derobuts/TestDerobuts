using DSAandAlgo.HashTable;
using Xunit;

namespace DSAandAlgo.Tests.HashTable;

public class RomanToIntTests
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void ParsesRomanNumerals(string input, int expected)
    {
        Assert.Equal(expected, new RomanToInt().Solve(input));
    }
}

public class NumberToWordsTests
{
    [Theory]
    [InlineData(0, "Zero")]
    [InlineData(123, "One Hundred Twenty Three")]
    [InlineData(12345, "Twelve Thousand Three Hundred Forty Five")]
    [InlineData(1234567, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")]
    [InlineData(1000000, "One Million")]
    public void ConvertsToEnglishWords(int input, string expected)
    {
        Assert.Equal(expected, new NumberToWords().Solve(input));
    }
}
