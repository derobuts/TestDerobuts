using System.Dynamic;

namespace DSAandAlgo.DataStructures;

public class HashMap<K, V>
{
    private List<Entry>[] buckets;
    private class Entry
    {
        public K Key;
        public V Value;
        public Entry(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }
    private int size;                    // number of key-value pairs
    private int capacity;
    private const double LoadFactorThreshold = 0.75;

    public HashMap(int capacity = 16)
    {
        this.capacity = capacity;
        buckets = new List<Entry>[capacity];
        size = 0;
    }
    
    private void Put(K key, V value)
    {
        int index = GetIndex(value);
        if (buckets[index] == null)
        {
            buckets[index] = new List<Entry>();
        }
        foreach (var entry in buckets[index])
        {
            if (entry.Key.Equals(value))
            {
                entry.Value = value;
                return;
            }
        }
        
        // new key ->
        buckets[index].Add(new Entry(key,value));
    }

    private int GetIndex(V value)
    {
        int hash = value.GetHashCode();
        int index = hash % capacity;
        return index;
    }
}