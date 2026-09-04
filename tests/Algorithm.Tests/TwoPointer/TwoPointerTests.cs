using DSAandAlgo.TwoPointer;
using Xunit;

namespace DSAandAlgo.Tests.TwoPointer;

public class MaxAreaTests
{
    [Fact]
    public void FindsMaxContainer()
    {
        Assert.Equal(49, new MaxArea().Solve(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
    }

    [Fact]
    public void HandlesTwoBars()
    {
        Assert.Equal(1, new MaxArea().Solve(new[] { 1, 1 }));
    }
}

public class MoveZeroesTests
{
    [Fact]
    public void PushesZeroesToEnd()
    {
        var arr = new[] { 0, 1, 0, 3, 12 };
        new MoveZeroes().Solve(arr);
        Assert.Equal(new[] { 1, 3, 12, 0, 0 }, arr);
    }

    [Fact]
    public void HandlesAllZeros()
    {
        var arr = new[] { 0, 0, 0 };
        new MoveZeroes().Solve(arr);
        Assert.Equal(new[] { 0, 0, 0 }, arr);
    }
}

public class TrapTests
{
    [Theory]
    [InlineData(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
    [InlineData(new[] { 4, 2, 0, 3, 2, 5 }, 9)]
    [InlineData(new int[] { }, 0)]
    public void TrapsRainWater(int[] heights, int expected)
    {
        Assert.Equal(expected, new Trap().Solve(heights));
    }
}

public class MaximumScoreTests
{
    [Theory]
    [InlineData(new[] { 1, 4, 3, 7, 4, 5 }, 3, 15)]
    [InlineData(new[] { 5, 5, 4, 5, 4, 1, 1, 1 }, 0, 20)]
    public void FindsMaxGoodSubarray(int[] nums, int k, int expected)
    {
        Assert.Equal(expected, new MaximumScore().Solve(nums, k));
    }
}

public class LongestBalancedTests
{
    [Theory]
    [InlineData(new[] { 0, 1 }, 2)]
    [InlineData(new[] { 0, 1, 0 }, 2)]
    [InlineData(new[] { 0, 0, 1, 0, 0, 0, 1, 1 }, 6)]
    [InlineData(new[] { 1, 1, 1, 1 }, 0)]
    public void FindsLongestEqualZerosAndOnes(int[] nums, int expected)
    {
        Assert.Equal(expected, new LongestBalanced().Solve(nums));
    }
}
