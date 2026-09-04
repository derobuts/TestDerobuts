namespace DSAandAlgo.Matrix;

/// <summary>
/// LeetCode 317 - Shortest Distance from All Buildings.
/// Given a grid where 1 is a building, 2 is an obstacle, and 0 is empty
/// land, find the empty cell that minimizes the total Manhattan-path
/// distance to all buildings (subject to obstacles). Return -1 if no such
/// cell exists.
/// </summary>
/// <example>
/// Input:
/// [[1,0,2,0,1],
///  [0,0,0,0,0],
///  [0,0,1,0,0]]
/// Output: 7
/// </example>
/// <remarks>
/// Approach: BFS from each building, accumulating the distance into and the
/// reach-count of every empty cell. The answer is the minimum totalDist of
/// any empty cell that was reached by every building. Time O(b * m * n)
/// where b is the number of buildings.
/// </remarks>
public class ShortestDistance
{
    private static readonly int[] DR = { -1, 1, 0, 0 };
    private static readonly int[] DC = { 0, 0, -1, 1 };

    public int Solve(int[][] grid)
    {
        if (grid == null || grid.Length == 0) return -1;

        int rows = grid.Length;
        int cols = grid[0].Length;

        int[][] totalDist = new int[rows][];
        int[][] reachCount = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            totalDist[i] = new int[cols];
            reachCount[i] = new int[cols];
        }

        int totalBuildings = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1) totalBuildings++;
            }
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] != 1) continue;

                var queue = new Queue<(int r, int c)>();
                var visited = new bool[rows, cols];

                queue.Enqueue((r, c));
                visited[r, c] = true;
                int dist = 0;

                while (queue.Count > 0)
                {
                    int size = queue.Count;
                    dist++;
                    for (int i = 0; i < size; i++)
                    {
                        var (rx, cx) = queue.Dequeue();
                        for (int d = 0; d < 4; d++)
                        {
                            int nr = rx + DR[d];
                            int nc = cx + DC[d];

                            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                            if (visited[nr, nc] || grid[nr][nc] != 0) continue;

                            visited[nr, nc] = true;
                            totalDist[nr][nc] += dist;
                            reachCount[nr][nc]++;
                            queue.Enqueue((nr, nc));
                        }
                    }
                }
            }
        }

        int min = int.MaxValue;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 0 && reachCount[r][c] == totalBuildings)
                {
                    min = Math.Min(min, totalDist[r][c]);
                }
            }
        }

        return min == int.MaxValue ? -1 : min;
    }
}
