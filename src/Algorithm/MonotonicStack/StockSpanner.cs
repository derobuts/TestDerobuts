namespace DSAandAlgo.MonotonicStack;

/// <summary>
/// LeetCode 901 - Online Stock Span.
/// Stream prices one at a time and after each return the "span" - the
/// number of consecutive days (including today) whose price was
/// &lt;= today's price.
/// </summary>
/// <example>
/// Sequence:
///   Next(100) -> 1
///   Next(80)  -> 1
///   Next(60)  -> 1
///   Next(70)  -> 2
///   Next(60)  -> 1
///   Next(75)  -> 4
///   Next(85)  -> 6
/// </example>
/// <remarks>
/// Approach: monotonic decreasing stack of (price, span) pairs. When a new
/// price comes in, pop and accumulate spans for every entry whose price is
/// &lt;= the new price; push the combined span. Amortized O(1) per call.
/// </remarks>
public class StockSpanner
{
    private readonly Stack<(int price, int span)> _stack = new();

    public int Next(int price)
    {
        int span = 1;
        while (_stack.Count > 0 && _stack.Peek().price <= price)
        {
            span += _stack.Pop().span;
        }
        _stack.Push((price, span));
        return span;
    }
}
