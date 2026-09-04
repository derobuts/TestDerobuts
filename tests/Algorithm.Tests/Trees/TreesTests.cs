using DSAandAlgo.Shared;
using DSAandAlgo.Trees;
using Xunit;

namespace DSAandAlgo.Tests.Trees;

public class InorderTraversalTests
{
    [Fact]
    public void VisitsLeftRootRight()
    {
        // Tree:
        //   1
        //    \
        //     2
        //    /
        //   3
        var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3)));
        Assert.Equal(new[] { 1, 3, 2 }, new InorderTraversal().Solve(root));
    }

    [Fact]
    public void EmptyTreeReturnsEmpty()
    {
        Assert.Empty(new InorderTraversal().Solve(null));
    }
}

public class IsSymmetricTests
{
    [Fact]
    public void DetectsMirroredTree()
    {
        // Mirrored
        //       1
        //      / \
        //     2   2
        //    / \ / \
        //   3 4 4   3
        var left = new TreeNode(2, new TreeNode(3), new TreeNode(4));
        var right = new TreeNode(2, new TreeNode(4), new TreeNode(3));
        Assert.True(new IsSymmetric().Solve(new TreeNode(1, left, right)));
    }

    [Fact]
    public void DetectsAsymmetricTree()
    {
        // Not mirrored
        var left = new TreeNode(2, right: new TreeNode(3));
        var right = new TreeNode(2, right: new TreeNode(3));
        Assert.False(new IsSymmetric().Solve(new TreeNode(1, left, right)));
    }
}
