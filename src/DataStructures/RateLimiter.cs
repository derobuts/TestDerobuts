namespace DSAandAlgo.DataStructures;

/// <summary>
/// Sliding-window rate limiter. For each user, allows at most
/// <c>maxRequests</c> calls within any rolling window of <c>windowMs</c>
/// milliseconds.
/// </summary>
/// <example>
/// var limiter = new RateLimiter(maxRequests: 3, windowMs: 1000);
/// limiter.Allow("alice"); // true
/// limiter.Allow("alice"); // true
/// limiter.Allow("alice"); // true
/// limiter.Allow("alice"); // false  (3 in the last 1s)
/// // ...wait 1s...
/// limiter.Allow("alice"); // true
/// </example>
/// <remarks>
/// Implementation: per-user deque of request timestamps. On each call,
/// drop timestamps older than <c>now - windowMs</c> from the front, then
/// check the remaining count. If under the cap, append the current time.
/// O(1) amortized per call.
/// </remarks>
public class RateLimiter
{
    private readonly int _maxRequests;
    private readonly long _windowMs;
    private readonly Dictionary<string, LinkedList<long>> _userRequests = new();

    public RateLimiter(int maxRequests, long windowMs)
    {
        _maxRequests = maxRequests;
        _windowMs = windowMs;
    }

    public bool Allow(string userId)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long cutoff = now - _windowMs;

        if (!_userRequests.TryGetValue(userId, out var deque))
        {
            deque = new LinkedList<long>();
            _userRequests[userId] = deque;
        }

        while (deque.Count > 0 && deque.First!.Value <= cutoff)
        {
            deque.RemoveFirst();
        }

        if (deque.Count >= _maxRequests) return false;

        deque.AddLast(now);
        return true;
    }
}
