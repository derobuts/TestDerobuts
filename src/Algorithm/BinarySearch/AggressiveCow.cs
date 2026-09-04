namespace DSAandAlgo.BinarySearch;

public class AggressiveCow
{
    /**
     * You have N stalls at positions given in an array (sorted or not).
    You must place C cows in these stalls.

    Place the cows so that the MINIMUM distance between any two cows
    is as LARGE as possible. Return that largest minimum distance.

    Example:
      positions = [1, 2, 4, 8, 9], C = 3
      → answer: 3
      (place cows at 1, 4, 8 → gaps are 3 and 4 → minimum gap = 3;
       no arrangement does better)
     */
    public int AggressiveCows(int[] positions, int c)
    {
        Array.Sort(positions);
        int l = 1;
        int r = positions[^1] - positions[0];

        int maxDistance = 0;
        
        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            if (canPlace(positions, c, mid))
            {
                maxDistance = mid;
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }
        return maxDistance;
    }

    bool canPlace(int[] stalls, int cows, int minDist)
    {
        int placedCows = 1;            // Place first cow in the first stall
        int lastPos = stalls[0];  // Last placed cow

        for (int i = 1; i < stalls.Length; i++) {
            // MaxMin we have to check if the lastPos and current position is at least as big as minDist
            // Note: we cannot invent new stall positions along the path. Stalls are fixed at those locations.
            if (stalls[i] - lastPos >= minDist) {
                placedCows++;
                lastPos = stalls[i];
                if (placedCows == cows)
                {
                    return true; // Successfully placed all cows
                }
            }
        }
        return false; // Not enough cows could be placed
    }
}