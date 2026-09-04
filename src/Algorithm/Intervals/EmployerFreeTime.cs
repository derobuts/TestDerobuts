namespace DSAandAlgo.Intervals;

/**
 * /**You are given a list of schedules for multiple employees where each schedule when they are busy. Each 
 * schedule is represented as an array of non-overlapping intervals. The goal is to find all the common
 * free times.
 * 
 */
public class EmployerFreeTime
{
    public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule)
    {
        var meetings = new List<(int time, int delta)>();
        foreach (var sched in schedule)
        {
            foreach (var meeting in sched)
            {
                var start = meeting.start;
                var end = meeting.end;
                meetings.Add((start, 1));
                meetings.Add((end, -1));
            }
        }
        meetings.Sort((a,b) => a.time.CompareTo(b.time));
        
        
    }
    
    public class Interval {
        public int start;
        public int end;

        public Interval(){}
        public Interval(int _start, int _end) {
            start = _start;
            end = _end;
        }
    }
}