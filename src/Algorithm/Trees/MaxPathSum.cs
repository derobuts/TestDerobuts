namespace DSAandAlgo.Trees;

public class MaxPathSum
{
    private int maxSum = int.MinValue;   // global answer, starts at MinValue

    public int MaxPathSum(TreeNode root) {
        MaxGain(root);
        return maxSum;
    }

    // Returns the max GAIN a path STARTING at `node` and going DOWN
    // (through at most ONE child) can contribute to its parent.
    private int MaxGain(TreeNode node) {
        if (node == null) return 0;

        // gains from children, dropping negatives (0 = don't go that way)
        int leftGain  = Math.Max(0, MaxGain(node.left));
        int rightGain = Math.Max(0, MaxGain(node.right));

        // RECORD: the path that PEAKS here (bends through node, uses BOTH)
        int pathThroughNode = node.val + leftGain + rightGain;
        maxSum = Math.Max(maxSum, pathThroughNode);

        // RETURN: a path the parent can EXTEND (node + ONE child only)
        return node.val + Math.Max(leftGain, rightGain);
    }
    
    public class TreeNode {
        public int val; 
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
        }
    }
}