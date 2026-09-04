public class Solution {
    public int ClosedIsland(int[][] grid) {
        int rLength = grid.Length;
        int cLength = grid[0].Length;
        var visited = new bool[rLength, cLength];

        // Sink all land connected to the border (can't be closed)
        for (int r = 0; r < rLength; r++) {
            DFS(grid, r, 0, visited);
            DFS(grid, r, cLength - 1, visited);
        }
        for (int c = 0; c < cLength; c++) {
            DFS(grid, 0, c, visited);
            DFS(grid, rLength - 1, c, visited);
        }

        // Count remaining (enclosed) islands
        int count = 0;
        for (int r = 0; r < rLength; r++) {
            for (int c = 0; c < cLength; c++) {
                if (grid[r][c] == 0 && !visited[r, c]) {   // unvisited land
                    DFS(grid, r, c, visited);
                    count++;
                }
            }
        }
        return count;
    }

    public void DFS(int[][] grid, int r, int c, bool[,] visited) {
        // 1. bounds check FIRST (before any grid[r] or visited[r,c] access)
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length)
            return;
        // 2. stop at water (1) OR already-visited
        if (grid[r][c] == 1 || visited[r, c])
            return;

        visited[r, c] = true;
        // (no need to set grid[r][c]=1 since visited[] already tracks it)

        DFS(grid, r + 1, c, visited);
        DFS(grid, r - 1, c, visited);
        DFS(grid, r, c + 1, visited);
        DFS(grid, r, c - 1, visited);
    }
}