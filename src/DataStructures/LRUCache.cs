namespace DSAandAlgo.DataStructures;

/// <summary>
/// LeetCode 146 - LRU Cache.
/// A fixed-capacity cache that evicts the least-recently-used entry when
/// full. Both <see cref="Get"/> and <see cref="Put"/> run in O(1) average
/// time.
/// </summary>
/// <example>
/// var cache = new LRUCache(2);
/// cache.Put(1, 1);          // {1=1}
/// cache.Put(2, 2);          // {1=1, 2=2}
/// cache.Get(1);             // returns 1; order is now {2=2, 1=1}
/// cache.Put(3, 3);          // evicts key 2; {1=1, 3=3}
/// cache.Get(2);             // returns -1 (not found)
/// </example>
/// <remarks>
/// Implementation: doubly-linked list of (key, value) nodes for O(1) move-
/// to-front, plus a dictionary mapping key -> node for O(1) lookup. Recent
/// items live at the head, the LRU at the tail.
/// </remarks>
public class LRUCache
{
    private class Node
    {
        public int Key;
        public int Value;
        public Node? Prev;
        public Node? Next;

        public Node(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }

    private readonly int _capacity;
    private readonly Dictionary<int, Node> _map = new();
    private readonly Node _head;
    private readonly Node _tail;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _head = new Node(0, 0);
        _tail = new Node(0, 0);
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public int Get(int key)
    {
        if (!_map.TryGetValue(key, out var node)) return -1;

        MoveToFront(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (_map.TryGetValue(key, out var existing))
        {
            existing.Value = value;
            MoveToFront(existing);
            return;
        }

        var node = new Node(key, value);
        _map[key] = node;
        AddAfter(_head, node);

        if (_map.Count > _capacity)
        {
            var lru = _tail.Prev!;
            Remove(lru);
            _map.Remove(lru.Key);
        }
    }

    private void MoveToFront(Node node)
    {
        Remove(node);
        AddAfter(_head, node);
    }

    private static void AddAfter(Node anchor, Node node)
    {
        node.Prev = anchor;
        node.Next = anchor.Next;
        anchor.Next!.Prev = node;
        anchor.Next = node;
    }

    private static void Remove(Node node)
    {
        node.Prev!.Next = node.Next;
        node.Next!.Prev = node.Prev;
    }
}
