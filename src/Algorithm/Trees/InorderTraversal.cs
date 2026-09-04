using DSAandAlgo.Shared;

namespace DSAandAlgo.Trees;

/// <summary>
/// LeetCode 94 - Binary Tree Inorder Traversal.
/// Return the inorder (left, root, right) traversal of the values in a
/// binary tree.
/// </summary>
/// <example>
/// Input:  root = [1,null,2,3]
///         1
///          \
///           2
///          /
///         3
/// Output: [1,3,2]
/// </example>
/// <example>
/// Input:  root = []     Output: []
/// </example>
/// <remarks>
/// Approach: recursive DFS. An iterative version using an explicit stack
/// works in the same O(n) time and O(h) space (h = tree height).
/// </remarks>
public class InorderTraversal
{
    public IList<int> Solve(TreeNode? root)
    {
        var list = new List<int>();
        Traverse(root, list);
        return list;
    }

    private void Traverse(TreeNode? node, List<int> list)
    {
        if (node == null) return;

        Traverse(node.left, list);
        list.Add(node.val);
        Traverse(node.right, list);
    }
}
