using DSAandAlgo.Permutation;
using Xunit;

namespace DSAandAlgo.Tests.Permutation;

public class PermuteTests
{
    [Fact]
    public void Enumerates3Permutations()
    {
        var result = new Permute().Solve(new[] { 1, 2, 3 });
        Assert.Equal(6, result.Count);

        var asSet = new HashSet<string>(result.Select(p => string.Join(",", p)));
        Assert.Contains("1,2,3", asSet);
        Assert.Contains("3,2,1", asSet);
        Assert.Equal(6, asSet.Count);
    }

    [Fact]
    public void HandlesPairs()
    {
        var result = new Permute().Solve(new[] { 0, 1 });
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void HandlesSingleton()
    {
        var result = new Permute().Solve(new[] { 5 });
        Assert.Single(result);
        Assert.Equal(5, result[0][0]);
    }
}
