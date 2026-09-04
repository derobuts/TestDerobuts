namespace DSAandAlgo.LineSweep;

/// <summary>
/// LeetCode 1094 - Car Pooling (line-sweep formulation).
/// You drive a car of capacity <c>capacity</c>. Each trip is
/// <c>[numPassengers, from, to]</c>. Return true iff you can complete every
/// trip without ever exceeding capacity. Dropoffs at L happen before pickups
/// at L (a passenger getting off frees a seat for someone boarding).
/// </summary>
/// <example>
/// Input:  trips=[[2,1,5],[3,3,7]], capacity=4   Output: false
/// Input:  trips=[[3,2,7],[3,7,9],[8,3,9]], capacity=11   Output: true
/// </example>
/// <remarks>
/// Approach: emit (+passengers) at pickup and (-passengers) at dropoff; sort
/// by location with dropoffs ordered first at ties; walk the events while
/// tracking the running occupancy. O(n log n).
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
