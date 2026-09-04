using DSAandAlgo.SlidingWindow;
using Xunit;

namespace DSAandAlgo.Tests.SlidingWindow;

public class LengthOfLongestSubstringTests
{
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("", 0)]
    [InlineData("dvdf", 3)]
    public void FindsLongestUniqueWindow(string input, int expected)
    {
        Assert.Equal(expected, new LengthOfLongestSubstring().Solve(input));
    }
}

public class MinWindowTests
{
    [Theory]
    [InlineData("ADOBECODEBANC", "ABC", "BANC")]
    [InlineData("a", "a", "a")]
    [InlineData("a", "aa", "")]
    public void FindsSmallestContainingWindow(string s, string t, string expected)
    {
        Assert.Equal(expected, new MinWindow().Solve(s, t));
    }
}

public class MaxSlidingWindowTests
{
    [Fact]
    public void FindsMaxPerWindow()
    {
        var result = new MaxSlidingWindow().Solve(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
        Assert.Equal(new[] { 3, 3, 5, 5, 6, 7 }, result);
    }
}
