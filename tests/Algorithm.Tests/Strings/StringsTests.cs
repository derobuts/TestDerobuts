using DSAandAlgo.Strings;
using Xunit;

namespace DSAandAlgo.Tests.Strings;

public class LongestPrefixTests
{
    [Theory]
    [InlineData("level", "l")]
    [InlineData("ababab", "abab")]
    [InlineData("leetcode", "")]
    [InlineData("a", "")]
    public void BruteForce_MatchesExpected(string input, string expected)
    {
        Assert.Equal(expected, new LongestPrefix().SolveBruteForce(input));
    }

    [Theory]
    [InlineData("level", "l")]
    [InlineData("ababab", "abab")]
    [InlineData("leetcode", "")]
    [InlineData("a", "")]
    public void RabinKarp_MatchesExpected(string input, string expected)
    {
        Assert.Equal(expected, new LongestPrefix().SolveRabinKarp(input));
    }
}

public class GroupAnagramsTests
{
    [Fact]
    public void GroupsAnagramsTogether()
    {
        var groups = new GroupAnagrams().Solve(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });

        var normalized = groups
            .Select(g => g.OrderBy(w => w, StringComparer.Ordinal).ToArray())
            .OrderBy(g => g[0], StringComparer.Ordinal)
            .ToArray();

        Assert.Equal(3, normalized.Length);
        Assert.Equal(new[] { "ate", "eat", "tea" }, normalized[0]);
        Assert.Equal(new[] { "bat" }, normalized[1]);
        Assert.Equal(new[] { "nat", "tan" }, normalized[2]);
    }

    [Fact]
    public void EmptyStringFormsItsOwnGroup()
    {
        var groups = new GroupAnagrams().Solve(new[] { "" });
        Assert.Single(groups);
        Assert.Equal("", groups[0][0]);
    }
}

public class DecodeStringTests
{
    [Theory]
    [InlineData("3[a]2[bc]", "aaabcbc")]
    [InlineData("3[a2[c]]", "accaccacc")]
    [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
    [InlineData("abc", "abc")]
    public void DecodesNestedRunLengthEncoding(string input, string expected)
    {
        Assert.Equal(expected, new DecodeString().Solve(input));
    }
}
