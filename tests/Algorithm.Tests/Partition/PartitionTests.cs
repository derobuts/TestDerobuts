using DSAandAlgo.Partition;
using Xunit;

namespace DSAandAlgo.Tests.Partition;

public class PalindromePartitionTests
{
    [Fact]
    public void EnumeratesAllPalindromicSplitsOfAab()
    {
        var result = new PalindromePartition().Solve("aab");
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void SingleCharHasOneSplit()
    {
        var result = new PalindromePartition().Solve("a");
        Assert.Single(result);
        Assert.Equal("a", result[0][0]);
    }
}

public class MinCutTests
{
    [Theory]
    [InlineData("aab", 1)]
    [InlineData("a", 0)]
    [InlineData("ab", 1)]
    [InlineData("aabb", 1)]
    public void ReturnsMinimumCuts(string input, int expected)
    {
        Assert.Equal(expected, new MinCut().Solve(input));
    }
}

public class MinimizeCostTests
{
    [Fact]
    public void ReturnsZeroWhenAlreadyPartitioned()
    {
        Assert.Equal(0, new MinimizeCost().Solve(new[] { 1, 1, 2, 2, 3, 3 }, 3));
    }
}
