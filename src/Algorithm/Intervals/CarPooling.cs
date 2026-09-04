namespace DSAandAlgo.Intervals;

/// <summary>
/// LeetCode 1094 - Car Pooling (event-based variant).
/// You drive a car of capacity <c>capacity</c>. Each trip is
/// <c>[numPassengers, from, to]</c>. Return true iff you can complete all
/// trips without ever exceeding capacity. Dropoffs at location L happen
/// before pickups at location L.
/// </summary>
/// <example>
/// Input:  trips=[[2,1,5],[3,3,7]], capacity=4   Output: false
/// Input:  trips=[[2,1,5],[3,3,7]], capacity=5   Output: true
/// </example>
/// <remarks>
/// Approach: build pickup/dropoff events keyed by location; sort with
/// dropoffs before pickups at the same location; walk the events and track
/// the running passenger count. See also <see cref="LineSweep.CarPooling"/>
/// for the same algorithm presented in the line-sweep folder.
/// </remarks>
public class CarPooling
{
    public bool Solve(int[][] trips, int capacity)
    {
        var events = new List<(int location, int passengers)>();

        foreach (var trip in trips)
        {
            events.Add((trip[1], trip[0]));
            events.Add((trip[2], -trip[0]));
        }

        events.Sort((a, b) => a.location == b.location
            ? a.passengers - b.passengers
            : a.location - b.location);

        int current = 0;
        foreach (var (_, passengers) in events)
        {
            current += passengers;
            if (current > capacity) return false;
        }

        return true;
    }
}
