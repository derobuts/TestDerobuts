using DSAandAlgo.Dfs;
using DSAandAlgo.Shared;
using Xunit;

namespace DSAandAlgo.Tests.Dfs;

public class DepthSumTests
{
    [Fact]
    public void WeightsByDepth()
    {
        // [[1,1],2,[1,1]] -> 1*2 + 1*2 + 2*1 + 1*2 + 1*2 = 10
        var inner1 = new NestedInteger();
        inner1.Add(new NestedInteger(1));
        inner1.Add(new NestedInteger(1));

        var inner2 = new NestedInteger();
        inner2.Add(new NestedInteger(1));
        inner2.Add(new NestedInteger(1));

        var list = new List<NestedInteger> { inner1, new NestedInteger(2), inner2 };
        Assert.Equal(10, new DepthSum().Solve(list));
    }

    [Fact]
    public void NestedExample()
    {
        // [1,[4,[6]]] -> 1*1 + 4*2 + 6*3 = 27
        var inner = new NestedInteger();
        inner.Add(new NestedInteger(6));

        var middle = new NestedInteger();
        middle.Add(new NestedInteger(4));
        middle.Add(inner);

        var list = new List<NestedInteger> { new(1), middle };
        Assert.Equal(27, new DepthSum().Solve(list));
    }
}

public class GetImportanceTests
{
    [Fact]
    public void SumsImportanceAcrossSubordinates()
    {
        var employees = new List<Employee>
        {
            new() { id = 1, importance = 5, subordinates = new List<int> { 2, 3 } },
            new() { id = 2, importance = 3, subordinates = new List<int>() },
            new() { id = 3, importance = 3, subordinates = new List<int>() },
        };
        Assert.Equal(11, new GetImportance().Solve(employees, 1));
    }
}
