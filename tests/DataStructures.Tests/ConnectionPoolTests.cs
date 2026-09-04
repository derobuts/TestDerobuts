using Xunit;

namespace DSAandAlgo.DataStructures.Tests;

public class ConnectionPoolTests
{
    [Fact]
    public async Task LeasesAndReleasesConnections()
    {
        var pool = new ConnectionPool(size: 2);

        var a = await pool.GetAsync();
        var b = await pool.GetAsync();
        Assert.NotSame(a, b);

        pool.Release(a);
        var c = await pool.GetAsync();
        Assert.Same(a, c);
    }
}
