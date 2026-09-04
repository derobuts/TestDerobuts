namespace DSAandAlgo.DataStructures;

/// <summary>
/// A fixed-size pool of reusable <see cref="Connection"/> objects. Callers
/// await <see cref="GetAsync"/> to lease a connection and call
/// <see cref="Release"/> to return it. If the pool is empty,
/// <see cref="GetAsync"/> blocks until one becomes available.
/// </summary>
/// <example>
/// var pool = new ConnectionPool(size: 5);
/// var conn = await pool.GetAsync();
/// try { /* use conn */ }
/// finally { pool.Release(conn); }
/// </example>
/// <remarks>
/// Implementation: a queue of free connections paired with a
/// <see cref="SemaphoreSlim"/> that gates concurrent leases. The semaphore
/// provides backpressure; the queue is only touched when the semaphore
/// allows entry, so the queue mutations don't need an additional lock.
/// </remarks>
public class ConnectionPool
{
    private readonly Queue<Connection> _available = new();
    private readonly SemaphoreSlim _semaphore;
    private readonly object _gate = new();

    public ConnectionPool(int size)
    {
        _semaphore = new SemaphoreSlim(size);
        for (int i = 0; i < size; i++)
        {
            _available.Enqueue(new Connection());
        }
    }

    public async Task<Connection> GetAsync()
    {
        await _semaphore.WaitAsync();
        lock (_gate)
        {
            return _available.Dequeue();
        }
    }

    public void Release(Connection conn)
    {
        lock (_gate)
        {
            _available.Enqueue(conn);
        }
        _semaphore.Release();
    }

    public class Connection
    {
    }
}
