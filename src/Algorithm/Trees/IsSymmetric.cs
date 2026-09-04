using DSAandAlgo.Shared;

namespace DSAandAlgo.Trees;

/// <summary>
/// LeetCode 101 - Symmetric Tree.
/// Return true iff the given binary tree is a mirror of itself around the
/// root (left subtree mirrors right subtree).
/// </summary>
/// <example>
/// Input:
///         1
///        / \
///       2   2
///      / \ / \
///     3  4 4  3
/// Output: true
/// </example>
/// <example>
/// Input:
///         1
///        / \
///       2   2
///        \   \
///        3    3
/// Output: false
/// </example>
/// <remarks>
/// Approach: BFS with two queues that walk the tree in mirrored order. At
/// each step compare the dequeued pair: both null = continue, one null = not
/// symmetric, values differ = not symmetric, otherwise enqueue children in
/// mirrored order (left.left vs right.right, left.right vs right.left). O(n).
/// </remarks>
public class IsSymmetric
{
    public bool Solve(TreeNode? root)
    {
        if (root == null) return true;

        var q1 = new Queue<TreeNode?>();
        var q2 = new Queue<TreeNode?>();

        q1.Enqueue(root.left);
        q2.Enqueue(root.right);

        while (q1.Count > 0 && q2.Count > 0)
        {
            var l = q1.Dequeue();
            var r = q2.Dequeue();

            if (l == null && r == null) continue;
            if (l == null || r == null) return false;
            if (l.val != r.val) return false;

            q1.Enqueue(l.left);
            q1.Enqueue(l.right);

            q2.Enqueue(r.right);
            q2.Enqueue(r.left);
        }

        return q1.Count == 0 && q2.Count == 0;
    }
}
