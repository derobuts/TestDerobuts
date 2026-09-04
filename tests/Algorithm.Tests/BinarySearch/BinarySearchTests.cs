using DSAandAlgo.BinarySearch;
using Xunit;

namespace DSAandAlgo.Tests.BinarySearch;

public class FindMedianSortedArraysTests
{
    [Theory]
    [InlineData(new[] { 1, 3 }, new[] { 2 }, 2.0)]
    [InlineData(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
    [InlineData(new int[] { }, new[] { 1 }, 1.0)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new int[] { }, 3.0)]
    public void ComputesMedianAcrossArrays(int[] a, int[] b, double expected)
    {
        Assert.Equal(expected, new FindMedianSortedArrays().Solve(a, b), 5);
    }
}
