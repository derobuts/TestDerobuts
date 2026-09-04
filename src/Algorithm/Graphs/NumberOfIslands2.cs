namespace DSAandAlgo.Matrix;

public class NumberOfIslands2
{
    public IList<int> NumIslands2(int m, int n, int[][] positions)
    {
        List<int> num = new List<int>();
        foreach (var positiond in positions)
        {
            setIslands2(positiond[0], positiond[1], positions);
            var result = NumIslands(positions);
            if (result > 0)
            {
                num.Add(result);
            }
        }
        return num;
    }
    
    public int NumIslands(int[][] grid)
    {
        int count = 0;
        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[0].Length; c++)
            {
                if (grid[r][c] == 1)
                {
                    DFS(grid, r, c);
                    count++;
                }
            }
        }
        return count;
    }

    private void DFS(int[][]grid, int r, int c)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length)
        {
            return;
        }

        if (grid[r][c] != 1)
        {
            return;
        }
        grid[r][c] = 2;
        DFS(grid, r + 1, c);
        DFS(grid, r - 1, c);
        DFS(grid, r, c + 1);
        DFS(grid, r, c - 1);
        grid[r][c] = 1;
    }

    public void setIslands2(int r, int c, int[][] positions)
    {
        positions[r][c] = 1;
    }
}