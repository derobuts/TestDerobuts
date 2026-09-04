namespace DSAandAlgo.Trees;

public class SerializeBinaryTree
{
    // Encodes a tree to a single string.
    public string serialize(Node root) {
        
    }
	
    // Decodes your encoded data to tree.
    public Node deserialize(string data) {
        
    }
    
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }
}