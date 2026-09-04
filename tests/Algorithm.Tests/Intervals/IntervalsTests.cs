using DSAandAlgo.Intervals;
using Xunit;

namespace DSAandAlgo.Tests.Intervals;

public class MinMeetingRoomsBruteForceTests
{
    [Theory]
    [InlineData(2, new[] { 0, 30, 5, 10, 15, 20 })]
    [InlineData(1, new[] { 7, 10, 2, 4 })]
    public void ReturnsExpectedRoomCount(int expected, int[] flat)
    {
        Assert.Equal(expected, new MinMeetingRoomsBruteForce().Solve(Unflatten(flat)));
    }

    private static int[][] Unflatten(int[] flat)
    {
        var r = new int[flat.Length / 2][];
        for (int i = 0; i < r.Length; i++) r[i] = new[] { flat[2 * i], flat[2 * i + 1] };
        return r;
    }
}

public class MinMeetingRoomsOptimizedTests
{
    [Theory]
    [InlineData(2, new[] { 0, 30, 5, 10, 15, 20 })]
    [InlineData(1, new[] { 7, 10, 2, 4 })]
    public void ReturnsExpectedRoomCount(int expected, int[] flat)
    {
        Assert.Equal(expected, new MinMeetingRoomsOptimized().Solve(Unflatten(flat)));
    }

    private static int[][] Unflatten(int[] flat)
    {
        var r = new int[flat.Length / 2][];
        for (int i = 0; i < r.Length; i++) r[i] = new[] { flat[2 * i], flat[2 * i + 1] };
        return r;
    }
}

public class AssignTasksTests
{
    [Fact]
    public void DispatchesByWeightThenIndex()
    {
        var result = new AssignTasks().Solve(new[] { 3, 3, 2 }, new[] { 1, 2, 3, 2, 1, 2 });
        Assert.Equal(new[] { 2, 2, 0, 2, 1, 2 }, result);
    }
}

public class BusiestServersTests
{
    [Fact]
    public void ReturnsServerHandlingMostRequests()
    {
        var result = new BusiestServers().BruteForceSolve(3, new[] { 1, 2, 3, 4, 5 }, new[] { 5, 2, 3, 3, 3 });
        Assert.Equal(new[] { 1 }, result);
    }
}

public class MostBookedTests
{
    [Fact]
    public void TracksRoomWithMostMeetings()
    {
        var meetings = new[]
        {
            new[] { 0, 10 }, new[] { 1, 5 }, new[] { 2, 7 }, new[] { 3, 4 }
        };
        Assert.Equal(0, new MostBooked().Solve(2, meetings));
    }
}

public class MaxEventsTests
{
    [Fact]
    public void AttendsAllNonConflictingEvents()
    {
        var events = new[] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 } };
        Assert.Equal(3, new MaxEvents().Solve(events));
    }
}

public class MaxValueTests
{
    [Fact]
    public void PicksHighestValuedKEvents()
    {
        var events = new[] { new[] { 1, 2, 4 }, new[] { 3, 4, 3 }, new[] { 2, 3, 1 } };
        Assert.Equal(7, new MaxValue().Solve(events, 2));
    }
}

public class CarPoolingIntervalsTests
{
    [Fact]
    public void RejectsOverCapacity()
    {
        var trips = new[] { new[] { 2, 1, 5 }, new[] { 3, 3, 7 } };
        Assert.False(new CarPooling().Solve(trips, 4));
    }

    [Fact]
    public void AcceptsAtCapacity()
    {
        var trips = new[] { new[] { 2, 1, 5 }, new[] { 3, 3, 7 } };
        Assert.True(new CarPooling().Solve(trips, 5));
    }
}

public class GetOrderTests
{
    [Fact]
    public void OrdersByProcessingTimeWithTiesByIndex()
    {
        var tasks = new[]
        {
            new[] { 1, 2 }, new[] { 2, 4 }, new[] { 3, 2 }, new[] { 4, 1 }
        };
        Assert.Equal(new[] { 0, 2, 3, 1 }, new GetOrder().Solve(tasks));
    }
}

public class CanAttendMeetingsTests
{
    [Fact]
    public void ReturnsFalseWhenOverlapExists()
    {
        var meetings = new[] { new[] { 0, 30 }, new[] { 5, 10 }, new[] { 15, 20 } };
        Assert.False(new CanAttendMeetings().Solve(meetings));
    }

    [Fact]
    public void ReturnsTrueWhenAllDisjoint()
    {
        var meetings = new[] { new[] { 7, 10 }, new[] { 2, 4 } };
        Assert.True(new CanAttendMeetings().Solve(meetings));
    }
}
