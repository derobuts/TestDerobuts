namespace DSAandAlgo.Matrix;

/// <summary>
/// LeetCode 490 - The Maze.
/// A ball placed in a maze can roll in one of four directions, but only
/// stops when it hits a wall (or the boundary). Given a 0/1 maze
/// (0 = empty, 1 = wall), a start, and a destination, return true iff the
/// ball can come to rest on the destination cell.
/// </summary>
/// <example>
/// Input:  maze=[
///   [0,0,1,0,0],
///   [0,0,0,0,0],
///   [0,0,0,1,0],
///   [1,1,0,1,1],
///   [0,0,0,0,0]
/// ], start=[0,4], destination=[4,4]
/// Output: true
/// </example>
/// <remarks>
/// Approach: DFS/BFS where each move rolls the ball until it hits a wall.
/// Cache visited *stopping positions* (not arbitrary cells) to avoid revisits.
/// O(m * n * max(m, n)).
/// </remarks>
public class HasPath
{
    private static readonly int[] DR = { -1, 1, 0, 0 };
    private static readonly int[] DC = { 0, 0, -1, 1 };

    public bool Solve(int[][] maze, int[] start, int[] destination)
    {
        if (maze.Length == 0 || maze[0].Length == 0) return false;

        int rows = maze.Length;
        int cols = maze[0].Length;
        var visited = new bool[rows, cols];

        return Dfs(maze, start[0], start[1], destination, visited);
    }

    private bool Dfs(int[][] maze, int r, int c, int[] destination, bool[,] visited)
    {
        if (visited[r, c])
        {
            return false;
        }
        
        if (r == destination[0] && c == destination[1])
        {
            return true;
        }

        visited[r, c] = true;

        for (int d = 0; d < 4; d++)
        {
            int nr = r;
            int nc = c;

            while (nr + DR[d] >= 0 && nr + DR[d] < maze.Length
                   && nc + DC[d] >= 0 && nc + DC[d] < maze[0].Length
                   && maze[nr + DR[d]][nc + DC[d]] == 0)
            {
                nr += DR[d];
                nc += DC[d];
            }

            if (Dfs(maze, nr, nc, destination, visited)) return true;
        }

        return false;
    }
}
