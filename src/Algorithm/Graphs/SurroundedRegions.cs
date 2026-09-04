namespace DSAandAlgo.Matrix;

/// <summary>
/// LeetCode 130 - Surrounded Regions.
/// Given an m x n board of 'X' and 'O', flip to 'X' every 'O' region that is
/// fully surrounded by 'X'. A region is surrounded iff none of its cells
/// touch the border. Mutates the board in place.
/// </summary>
/// <example>
/// Input:
/// X X X X
/// X O O X
/// X X O X
/// X O X X
/// Output:
/// X X X X
/// X X X X
/// X X X X
/// X O X X
/// </example>
/// <remarks>
/// Approach: any 'O' that can reach the border is safe, so DFS/BFS from each
/// border 'O' and mark it as 'S' (safe). After the sweep, every remaining
/// 'O' is surrounded - flip to 'X', and restore 'S' back to 'O'. O(m * n).
/// </remarks>
public class SurroundedRegions
{
    private static readonly int[] DR = { -1, 1, 0, 0 };
    private static readonly int[] DC = { 0, 0, -1, 1 };

    public void Solve(char[][] board)
    {
        if (board.Length == 0 || board[0].Length == 0) return;

        int rows = board.Length;
        int cols = board[0].Length;

        for (int r = 0; r < rows; r++)
        {
            MarkSafe(board, r, 0);
            MarkSafe(board, r, cols - 1);
        }
        for (int c = 0; c < cols; c++)
        {
            MarkSafe(board, 0, c);
            MarkSafe(board, rows - 1, c);
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (board[r][c] == 'O') board[r][c] = 'X';
                else if (board[r][c] == 'S') board[r][c] = 'O';
            }
        }
    }

    private void MarkSafe(char[][] board, int r, int c)
    {
        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length) return;
        if (board[r][c] != 'O') return;

        board[r][c] = 'S';
        for (int d = 0; d < 4; d++)
        {
            MarkSafe(board, r + DR[d], c + DC[d]);
        }
    }
}
