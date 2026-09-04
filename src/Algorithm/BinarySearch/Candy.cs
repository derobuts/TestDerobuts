namespace DSAandAlgo.BinarySearch;

/**
 * PROBLEM: Maximum Candies Allocated to K Children (LC 2226)
 *
 * GIVEN:
 * - An array `candies[]` where candies[i] is the size of the i-th pile
 * - A long `k`, the number of children
 *
 * RULES:
 * 1. A pile may be split into sub-piles, but sub-piles are never merged
 * 2. Every child gets exactly one sub-pile of the same size, or nothing
 *
 * GOAL:
 * - Maximise the number of candies a single child receives
 *
 * INTUITION:
 * 1. Candidate answer = candies per child
 * 2. Feasibility: a pile of size p yields p / size children, so the total is
 *    sum(p / size). Feasible when that total >= k.
 * 3. Monotone: if `size` is feasible, every smaller size is too. So binary
 *    search the largest feasible size.
 *
 * SEARCH SPACE: [1 .. max(candies)]
 *
 * Time:  O(n log m)  - n = piles, m = largest pile
 * Space: O(1)
 */
public class Candy
{
    public int Solve(int[] candies, long k)
    {
        if (candies.Length == 0) return 0;

        int left = 1;
        int right = candies.Max();
        int result = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (CanServe(candies, k, mid))
            {
                result = mid;       // feasible, try for more
                left = mid + 1;
            }
            else
            {
                right = mid - 1;    // too greedy, back off
            }
        }

        return result;
    }

    // How many children can be served if each gets `candiesPerChild`?
    private static bool CanServe(int[] candies, long k, int candiesPerChild)
    {
        long served = 0;
        foreach (int pile in candies)
        {
            served += pile / candiesPerChild;
            if (served >= k) return true;   // early exit, avoids overflow
        }
        return false;
    }
}
