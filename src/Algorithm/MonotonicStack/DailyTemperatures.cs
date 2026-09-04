namespace DSAandAlgo.MonotonicStack;

/// <summary>
/// LeetCode 739 - Daily Temperatures.
/// For each day's temperature, return how many days you must wait until a
/// warmer temperature. If there is no such day, the entry is 0.
/// </summary>
/// <example>
/// Input:  [73,74,75,71,69,72,76,73]
/// Output: [1,1,4,2,1,1,0,0]
/// </example>
/// <remarks>
/// Approach: monotonic stack of indices (temperatures decreasing toward the
/// top). When a warmer day comes in, pop everything cooler and write the
/// distance. O(n) since each index is pushed and popped at most once.
/// </remarks>
public class DailyTemperatures
{
    public int[] Solve(int[] temperatures)
    {
        var stack = new Stack<int>();
        var days = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int index = stack.Pop();
                days[index] = i - index;
            }
            stack.Push(i);
        }

        return days;
    }
}
