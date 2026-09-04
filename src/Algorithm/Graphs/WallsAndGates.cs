namespace DSAandAlgo.Matrix;

/// <summary>
/// LeetCode 286 - Walls and Gates.
/// You have a 2D grid where -1 is a wall, 0 is a gate, and 2147483647
/// (int.MaxValue) is an empty room. Fill each empty room with the distance
/// to its nearest gate. If a room cannot reach a gate it stays at
/// int.MaxValue. Mutates the grid in place.
/// </summary>
/// <example>
/// Input:
/// [[INF, -1,   0,  INF],
///  [INF, INF, INF, -1],
///  [INF, -1,  INF, -1],
///  [0,   -1,  INF, INF]]
/// Output:
/// [[3, -1,  0,  1],
///  [2,  2,  1, -1],
///  [1, -1,  2, -1],
///  [0, -1,  3,  4]]
/// </example>
/// <remarks>
/// Approach: multi-source BFS starting from every gate simultaneously. Each
/// cell is visited once, so this is O(rows * cols). Pushing only updated
/// cells onto the queue is what makes this efficient compared to per-cell
/// BFS.
/// </remarks>
public class WallsAndGates
{
    private const int Empty = int.MaxValue;
    private const int Gate = 0;
    private const int Wall = -1;
    private static readonly int[] DR = { -1, 1, 0, 0 };
    private static readonly int[] DC = { 0, 0, -1, 1 };

    public void Solve(int[][] rooms)
    {
        if (rooms.Length == 0 || rooms[0].Length == 0) return;

        int rows = rooms.Length;
        int cols = rooms[0].Length;
        var queue = new Queue<(int r, int c)>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (rooms[r][c] == Gate) queue.Enqueue((r, c));
            }
        }

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();

            for (int d = 0; d < 4; d++)
            {
                int nr = r + DR[d];
                int nc = c + DC[d];

                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                if (rooms[nr][nc] != Empty) continue;

                rooms[nr][nc] = rooms[r][c] + 1;
                queue.Enqueue((nr, nc));
            }
        }
    }
}
