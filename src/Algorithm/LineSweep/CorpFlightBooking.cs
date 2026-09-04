namespace DSAandAlgo.LineSweep;

public class CorpFlightBooking
{
    /**
     * n flights labeled 1 to n. bookings[i] = [first, last, seats] means
        `seats` seats reserved on EACH flight from `first` to `last` inclusive.

        Return an array answer of length n where answer[i] = total seats
        reserved for flight i+1.

        Example:
          bookings = [[1,2,10],[2,3,20],[2,5,25]], n = 5
          → [10, 55, 45, 25, 25]

        Pattern: DIFFERENCE ARRAY (event sweep's cousin). +seats at `first`,
        -seats at `last+1`, then take a running prefix sum. O(n) instead of
        updating every flight in every range. This is the KEY sweep trick.
     */
    public int[] CorpFlightBookings(int[][] bookings, int n) {
        int[] results = new int[n];

        foreach (var booking in bookings) {
            int first = booking[0], last = booking[1], seats = booking[2];

            for (int f = first; f <= last; f++)
                results[f - 1] += seats;     // += to accumulate, f-1 for 0-index
        }
        return results;
    }
}