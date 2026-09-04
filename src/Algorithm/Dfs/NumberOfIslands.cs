namespace DSAandAlgo.Dfs;

/**
 * Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.


Example 1:

Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1
Example 2:

Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
 */
public class NumberOfIslands
{
    public int solve(char[][] grid) {
        // Base case: empty grid check
        if (grid == null || grid.Length == 0) {
            return 0;
        }

        int numIslands = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;

        // Iterate through every cell in the grid
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                // If we find an unvisited part of an island ('1')
                if (grid[i][j] == '1') {
                    numIslands++; // Increment the island count
                    // Trigger DFS to mark the entire island as visited
                    dfs(grid, i, j, rows, cols);
                }
            }
        }

        return numIslands;
    }

    /**
     * Depth-First Search helper to traverse and sink the current island.
     * Sinking the island (turning '1's into '0's) prevents us from counting the same island twice.
     */
    private void dfs(char[][] grid, int i, int j, int rows, int cols) {
        // Boundary checks and water/visited check
        if (i < 0 || i >= rows || j < 0 || j >= cols || grid[i][j] == '0') {
            return;
        }

        // Mark the current cell as visited by setting it to '0' (water)
        grid[i][j] = '0';

        // Recursively visit all 4 adjacent directions (up, down, left, right)
        dfs(grid, i + 1, j, rows, cols); // down
        dfs(grid, i - 1, j, rows, cols); // up
        dfs(grid, i, j + 1, rows, cols); // right
        dfs(grid, i, j - 1, rows, cols); // left
    }
}