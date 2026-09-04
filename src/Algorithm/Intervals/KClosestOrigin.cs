namespace DSAandAlgo.Intervals;

/**
 * K Closest Points to Origin (LC 973)
 *
 * Keep a BOUNDED MAX-HEAP of size k. The farthest surviving point sits on
 * top, so when the heap overflows we evict exactly the point we no longer
 * care about. .NET's PriorityQueue is a MIN-heap, so we negate the priority
 * to simulate a max-heap.
 *
 * Comparing squared distance avoids a sqrt and stays in integer arithmetic.
 *
 * Time:  O(n log k)
 * Space: O(k)
 */
public class KClosestOrigin
{
    public int[][] Solve(int[][] points, int k)
    {
        // priority = -dist², so the LARGEST distance has the SMALLEST priority
        // and is what TryDequeue hands back first.
        var heap = new PriorityQueue<int[], int>();

        foreach (var point in points)
        {
            int dist = point[0] * point[0] + point[1] * point[1];   // dist², no sqrt
            heap.Enqueue(point, -dist);

            if (heap.Count > k)
            {
                heap.Dequeue();     // evict the farthest
            }
        }

        var result = new int[heap.Count][];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = heap.Dequeue();
        }
        return result;
    }
}
