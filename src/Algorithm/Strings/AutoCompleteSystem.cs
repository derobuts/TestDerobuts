namespace DSAandAlgo.Strings;

public class AutoCompleteSystem
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> children = new();
        public bool isEnd = false;
    }

    private TrieNode _root = new();
    public void Insert(string word)
    {
        var current = _root;
        foreach (char c in word)
        {
            if (current.children.TryGetValue(c, out var child))
            {
                
            }
        }
    }
}