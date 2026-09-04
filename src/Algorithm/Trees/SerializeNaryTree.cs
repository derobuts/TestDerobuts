using System.Text;

public class SerializeNaryTree {
    // SERIALIZE: preorder, "val count" space-separated for each node
    public string serialize(Node root) {
        if (root == null) return "";
        var sb = new StringBuilder();
        SerializeHelper(root, sb);
        return sb.ToString().Trim();
    }

    private void SerializeHelper(Node node, StringBuilder sb) {
        if (node == null) return;
        sb.Append(node.val).Append(' ');              // val, then space
        sb.Append(node.children.Count).Append(' ');   // count, then space
        foreach (var child in node.children)
            SerializeHelper(child, sb);
    }

    // DESERIALIZE: read val, read count, build exactly count children
    public Node deserialize(string data) {
        if (string.IsNullOrEmpty(data)) return null;
        var tokens = data.Split(' ');
        int index = 0;
        return DeserializeHelper(tokens, ref index);
    }

    private Node DeserializeHelper(string[] tokens, ref int index) {
        int val = int.Parse(tokens[index++]);          // parse whole token
        int childCount = int.Parse(tokens[index++]);   // next token = count
        var node = new Node(val);
        node.children = new List<Node>();
        for (int i = 0; i < childCount; i++)           // loop count TIMES
            node.children.Add(DeserializeHelper(tokens, ref index));  // shared cursor
        return node;
    }
    public class Node {
        public int val;
        public IList<Node> children;
        public Node() { children = new List<Node>(); }
        public Node(int _val) { val = _val; children = new List<Node>(); }
        public Node(int _val, IList<Node> _children) { val = _val; children = _children; }
    }
}