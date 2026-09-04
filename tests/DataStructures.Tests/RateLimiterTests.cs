using Xunit;

namespace DSAandAlgo.DataStructures.Tests;

public class RateLimiterTests
{
    [Fact]
    public void RejectsAfterReachingLimitWithinWindow()
    {
        var sut = new RateLimiter(maxRequests: 3, windowMs: 60_000);

        Assert.True(sut.Allow("user-1"));
        Assert.True(sut.Allow("user-1"));
        Assert.True(sut.Allow("user-1"));
        Assert.False(sut.Allow("user-1"));
    }

    [Fact]
    public void TracksUsersIndependently()
    {
        var sut = new RateLimiter(maxRequests: 1, windowMs: 60_000);

        Assert.True(sut.Allow("alice"));
        Assert.True(sut.Allow("bob"));
        Assert.False(sut.Allow("alice"));
        Assert.False(sut.Allow("bob"));
    }
}
