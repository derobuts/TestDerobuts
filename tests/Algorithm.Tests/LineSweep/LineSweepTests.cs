using DSAandAlgo.LineSweep;
using DSAandAlgo.Shared;
using Xunit;

namespace DSAandAlgo.Tests.LineSweep;

public class CarPoolingLineSweepTests
{
    [Fact]
    public void AcceptsWhenWithinCapacity()
    {
        var trips = new[] { new[] { 2, 1, 5 }, new[] { 3, 3, 7 } };
        Assert.True(new CarPooling().Solve(trips, 5));
    }

    [Fact]
    public void RejectsOverCapacity()
    {
        var trips = new[] { new[] { 2, 1, 5 }, new[] { 3, 3, 7 } };
        Assert.False(new CarPooling().Solve(trips, 4));
    }
}

public class MinMeetingRoomsLineSweepTests
{
    [Theory]
    [InlineData(2, new[] { 0, 30, 5, 10, 15, 20 })]
    [InlineData(1, new[] { 7, 10, 2, 4 })]
    public void ReturnsExpectedRoomCount(int expected, int[] flat)
    {
        var intervals = new int[flat.Length / 2][];
        for (int i = 0; i < intervals.Length; i++)
            intervals[i] = new[] { flat[2 * i], flat[2 * i + 1] };

        Assert.Equal(expected, new MinMeetingRooms().Solve(intervals));
    }
}

public class EmployeeFreeTimeTests
{
    [Fact]
    public void FindsCommonFreeIntervals()
    {
        var schedule = new List<IList<Interval>>
        {
            new List<Interval> { new(1, 2), new(5, 6) },
            new List<Interval> { new(1, 3) },
            new List<Interval> { new(4, 10) },
        };

        var free = new EmployeeFreeTime().Solve(schedule);
        Assert.Single(free);
        Assert.Equal(3, free[0].start);
        Assert.Equal(4, free[0].end);
    }
}
