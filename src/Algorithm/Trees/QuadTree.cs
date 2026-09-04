namespace DSAandAlgo.Trees;

/**
 * Construct Quad Tree (LC 427)
 *
 * A quad tree encodes an n x n binary grid (n is a power of two):
 * - A LEAF covers a region where every cell is identical; `val` is that cell.
 * - An INTERNAL node splits its region into four equal quadrants.
 *
 * Recursion: if the region is uniform emit a leaf, otherwise split into four
 * halves and recurse. A parent whose four children are identical leaves
 * collapses back into a single leaf.
 *
 * Time:  O(n^2 log n) - each of the log n levels scans O(n^2) cells for uniformity
 * Space: O(n^2)       - nodes emitted in the worst case (checkerboard grid)
 */
public class QuadTree
{
    public Node? Solve(int[][] grid)
    {
        if (grid.Length == 0) return null;
        return Build(grid, 0, 0, grid.Length);
    }

    // Build a quad tree for the size x size square with top-left at (row, col).
    private static Node Build(int[][] grid, int row, int col, int size)
    {
        // 1. BASE CASE: uniform region -> leaf
        if (IsUniform(grid, row, col, size))
        {
            return new Node(grid[row][col] == 1, true);
        }

        // 2. RECURSE: four quadrants of size/2
        int half = size / 2;
        Node tl = Build(grid, row, col, half);
        Node tr = Build(grid, row, col + half, half);
        Node bl = Build(grid, row + half, col, half);
        Node br = Build(grid, row + half, col + half, half);

        // 3. COMBINE: internal node holding the four children
        return new Node(true, false)
        {
            topLeft = tl,
            topRight = tr,
            bottomLeft = bl,
            bottomRight = br,
        };
    }

    // Is every cell in the size x size square the same value?
    private static bool IsUniform(int[][] grid, int row, int col, int size)
    {
        int first = grid[row][col];
        for (int r = row; r < row + size; r++)
        for (int c = col; c < col + size; c++)
            if (grid[r][c] != first) return false;
        return true;
    }

    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node? topLeft, topRight, bottomLeft, bottomRight;

        public Node() { }

        public Node(bool val, bool isLeaf)
        {
            this.val = val;
            this.isLeaf = isLeaf;
        }
    }
}
