using Xunit;

namespace DSAandAlgo.DataStructures.Tests;

public class LRUCacheTests
{
    [Fact]
    public void EvictsLeastRecentlyUsed()
    {
        var cache = new LRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);

        Assert.Equal(1, cache.Get(1));   // {2=2, 1=1}
        cache.Put(3, 3);                  // evicts 2 -> {1=1, 3=3}
        Assert.Equal(-1, cache.Get(2));

        cache.Put(4, 4);                  // evicts 1 -> {3=3, 4=4}
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(3, cache.Get(3));
        Assert.Equal(4, cache.Get(4));
    }

    [Fact]
    public void UpdatesValueAndRefreshesRecency()
    {
        var cache = new LRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Put(1, 11);                 // refresh recency on 1
        cache.Put(3, 3);                  // evicts 2 (least recent)

        Assert.Equal(11, cache.Get(1));
        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(3, cache.Get(3));
    }
}
