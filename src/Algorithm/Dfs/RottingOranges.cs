namespace DSAandAlgo.Dfs;

public class RottingOranges
{
    /**
     * You are given an m x n grid where each cell can have one of three values:

        0 representing an empty cell,
        1 representing a fresh orange, or
        2 representing a rotten orange.
        Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

     */
    public int OrangesRotting(int[][] grid)
    {
        int rows = grid.Length;
        if (rows == 0) return -1;
        int cols = grid[0].Length;
        
        Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
        int freshCount = 0;

        // Step 1: Initialize the queue with all initially rotten oranges and count fresh ones
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 2)
                {
                    queue.Enqueue((r, c)); // Add rotten orange to queue
                }
                else if (grid[r][c] == 1)
                {
                    freshCount++; // Keep track of how many fresh oranges exist
                }
            }
        }

        // Base case: If there are no fresh oranges to begin with, 0 minutes are needed.
        if (freshCount == 0) return 0;

        int minutes = 0;
        // The 4 directional movements: Up, Down, Left, Right
        int[][] directions = new int[][] 
        {
            new int[] {-1, 0}, 
            new int[] {1, 0}, 
            new int[] {0, -1}, 
            new int[] {0, 1}
        };

        // Step 2: Process the queue level by level (minute by minute)
        while (queue.Count > 0 && freshCount > 0)
        {
            int currentLevelSize = queue.Count;
            
            for (int i = 0; i < currentLevelSize; i++)
            {
                var (r, c) = queue.Dequeue();

                // Check all 4 adjacent neighbors
                foreach (var dir in directions)
                {
                    int newRow = r + dir[0];
                    int newCol = c + dir[1];

                    // If neighbor is within bounds and is a fresh orange
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1)
                    {
                        grid[newRow][newCol] = 2; // Make it rotten
                        freshCount--; // We have one less fresh orange
                        queue.Enqueue((newRow, newCol)); // Add newly rotten orange to queue for next minute
                    }
                }
            }
            
            minutes++; // 1 minute has passed after processing all current rotten oranges
        }

        // Step 3: Check if all oranges rotted
        return freshCount == 0 ? minutes : -1;
    }
}