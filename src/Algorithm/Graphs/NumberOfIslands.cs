namespace DSAandAlgo.Matrix;

/**
 * Number of Islands (LC 200) - grid variant kept under Matrix.
 * See DSAandAlgo.Dfs.NumberOfIslands for the annotated walkthrough.
 *
 * Time:  O(r * c) - every cell is visited at most twice
 * Space: O(r * c) - worst-case recursion depth on an all-land grid
 */
public class NumberOfIslands
{
    public int Solve(char[][] grid)
    {
        if (grid.Length == 0) return 0;

        int count = 0;
        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[0].Length; c++)
            {
                if (grid[r][c] == '1')
                {
                    Sink(grid, r, c);
                    count++;
                }
            }
        }
        return count;
    }

    // Flood-fill the island rooted at (r, c), marking land as visited.
    private static void Sink(char[][] grid, int r, int c)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length) return;
        if (grid[r][c] != '1') return;          // water or already sunk

        grid[r][c] = '0';
        Sink(grid, r + 1, c);
        Sink(grid, r - 1, c);
        Sink(grid, r, c + 1);
        Sink(grid, r, c - 1);
    }
}
