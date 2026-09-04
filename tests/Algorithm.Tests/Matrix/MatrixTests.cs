using DSAandAlgo.Matrix;
using Xunit;

namespace DSAandAlgo.Tests.Matrix;

public class WallsAndGatesTests
{
    [Fact]
    public void FillsDistancesFromGates()
    {
        const int INF = int.MaxValue;
        var rooms = new[]
        {
            new[] { INF, -1, 0,   INF },
            new[] { INF, INF, INF, -1 },
            new[] { INF, -1,  INF, -1 },
            new[] { 0,   -1,  INF, INF },
        };

        new WallsAndGates().Solve(rooms);

        var expected = new[]
        {
            new[] { 3, -1, 0,  1 },
            new[] { 2,  2, 1, -1 },
            new[] { 1, -1, 2, -1 },
            new[] { 0, -1, 3,  4 },
        };

        for (int r = 0; r < expected.Length; r++)
        {
            Assert.Equal(expected[r], rooms[r]);
        }
    }
}

public class SurroundedRegionsTests
{
    [Fact]
    public void CapturesOnlyEnclosedRegions()
    {
        var board = new[]
        {
            new[] { 'X', 'X', 'X', 'X' },
            new[] { 'X', 'O', 'O', 'X' },
            new[] { 'X', 'X', 'O', 'X' },
            new[] { 'X', 'O', 'X', 'X' },
        };

        new SurroundedRegions().Solve(board);

        var expected = new[]
        {
            new[] { 'X', 'X', 'X', 'X' },
            new[] { 'X', 'X', 'X', 'X' },
            new[] { 'X', 'X', 'X', 'X' },
            new[] { 'X', 'O', 'X', 'X' },
        };

        for (int r = 0; r < expected.Length; r++)
        {
            Assert.Equal(expected[r], board[r]);
        }
    }
}

public class ShortestDistanceTests
{
    [Fact]
    public void FindsBestEmptyCell()
    {
        var grid = new[]
        {
            new[] { 1, 0, 2, 0, 1 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { 0, 0, 1, 0, 0 },
        };
        Assert.Equal(7, new ShortestDistance().Solve(grid));
    }
}

public class HasPathTests
{
    [Fact]
    public void RollsToDestination()
    {
        var maze = new[]
        {
            new[] { 0, 0, 1, 0, 0 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { 0, 0, 0, 1, 0 },
            new[] { 1, 1, 0, 1, 1 },
            new[] { 0, 0, 0, 0, 0 },
        };
        Assert.True(new HasPath().Solve(maze, new[] { 0, 4 }, new[] { 4, 4 }));
    }

    [Fact]
    public void ReturnsFalseWhenUnreachable()
    {
        var maze = new[]
        {
            new[] { 0, 0, 1, 0, 0 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { 0, 0, 0, 1, 0 },
            new[] { 1, 1, 0, 1, 1 },
            new[] { 0, 0, 0, 0, 0 },
        };
        Assert.False(new HasPath().Solve(maze, new[] { 0, 4 }, new[] { 3, 2 }));
    }
}
