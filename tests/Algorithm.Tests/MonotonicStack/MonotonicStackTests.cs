using DSAandAlgo.MonotonicStack;
using Xunit;

namespace DSAandAlgo.Tests.MonotonicStack;

public class DailyTemperaturesTests
{
    [Fact]
    public void CountsDaysUntilWarmer()
    {
        Assert.Equal(
            new[] { 1, 1, 4, 2, 1, 1, 0, 0 },
            new DailyTemperatures().Solve(new[] { 73, 74, 75, 71, 69, 72, 76, 73 }));
    }
}

public class NextGreaterElementTests
{
    [Fact]
    public void MapsByValue()
    {
        Assert.Equal(
            new[] { -1, 3, -1 },
            new NextGreaterElement().Solve(new[] { 4, 1, 2 }, new[] { 1, 3, 4, 2 }));
    }

    [Fact]
    public void AnotherExample()
    {
        Assert.Equal(
            new[] { 3, -1 },
            new NextGreaterElement().Solve(new[] { 2, 4 }, new[] { 1, 2, 3, 4 }));
    }
}

public class MaxNumberTests
{
    [Fact]
    public void PicksLargestKDigitSubsequence()
    {
        Assert.Equal(new[] { 6, 5 }, new MaxNumber().Solve(new[] { 3, 4, 6, 5 }, 2));
    }

    [Fact]
    public void PicksTopThree()
    {
        Assert.Equal(new[] { 9, 8, 3 }, new MaxNumber().Solve(new[] { 9, 1, 2, 5, 8, 3 }, 3));
    }
}

public class LexSmallestAfterDeletionTests
{
    [Theory]
    [InlineData("1432219", 3, "1219")]
    [InlineData("10200", 1, "200")]
    [InlineData("10", 2, "0")]
    public void RemovesKDigitsForSmallestResult(string input, int k, string expected)
    {
        Assert.Equal(expected, new LexSmallestAfterDeletion().Solve(input, k));
    }
}

public class RemoveDuplicateLettersTests
{
    [Theory]
    [InlineData("bcabc", "abc")]
    [InlineData("cbacdcbc", "acdb")]
    public void KeepsLexSmallestNoDup(string input, string expected)
    {
        Assert.Equal(expected, new RemoveDuplicateLetters().Solve(input));
    }
}

public class StockSpannerTests
{
    [Fact]
    public void TracksConsecutiveLowerOrEqual()
    {
        var sut = new StockSpanner();
        Assert.Equal(1, sut.Next(100));
        Assert.Equal(1, sut.Next(80));
        Assert.Equal(1, sut.Next(60));
        Assert.Equal(2, sut.Next(70));
        Assert.Equal(1, sut.Next(60));
        Assert.Equal(4, sut.Next(75));
        Assert.Equal(6, sut.Next(85));
    }
}
