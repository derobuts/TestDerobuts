namespace DSAandAlgo.Matrix;

/**
 * Pacific Atlantic Water Flow (LC 417)
 *
 * Water flows from a cell to a 4-directional neighbour of EQUAL OR LOWER
 * height. Return every cell that can reach both oceans.
 *
 * KEY INSIGHT: don't ask "where can this cell drain to?" for every cell -
 * that re-walks the grid n^2 times. Invert it: start AT each ocean's border
 * and walk UPHILL. Two reachability sets, then intersect them.
 *
 * Time:  O(r * c) - each cell is entered at most once per ocean
 * Space: O(r * c) - two visited grids plus recursion depth
 */
public class PacificAtlantic
{
    private static readonly int[][] Directions =
    [
        [1, 0], [-1, 0], [0, 1], [0, -1]
    ];

    public IList<IList<int>> Solve(int[][] heights)
    {
        var result = new List<IList<int>>();
        if (heights.Length == 0 || heights[0].Length == 0) return result;

        int rows = heights.Length;
        int cols = heights[0].Length;

        var pacific = new bool[rows, cols];
        var atlantic = new bool[rows, cols];

        // Pacific touches the top row and left column.
        // Atlantic touches the bottom row and right column.
        for (int r = 0; r < rows; r++)
        {
            Uphill(heights, r, 0, pacific);
            Uphill(heights, r, cols - 1, atlantic);
        }
        for (int c = 0; c < cols; c++)
        {
            Uphill(heights, 0, c, pacific);
            Uphill(heights, rows - 1, c, atlantic);
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (pacific[r, c] && atlantic[r, c])
                {
                    result.Add(new List<int> { r, c });
                }
            }
        }
        return result;
    }

    // Walk from (r, c) to neighbours that are at least as high - i.e. the
    // cells whose water would flow back down into (r, c).
    private static void Uphill(int[][] heights, int r, int c, bool[,] visited)
    {
        visited[r, c] = true;
        foreach (var dir in Directions)
        {
            int nr = r + dir[0];
            int nc = c + dir[1];

            if (nr < 0 || nr >= heights.Length || nc < 0 || nc >= heights[0].Length) continue;
            if (visited[nr, nc]) continue;
            if (heights[nr][nc] < heights[r][c]) continue;   // water can't climb down into us

            Uphill(heights, nr, nc, visited);
        }
    }
}
