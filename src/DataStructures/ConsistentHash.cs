using System.Security.Cryptography;
using System.Text;

namespace DSAandAlgo.DataStructures;

public class ConsistentHash
{
    private readonly SortedDictionary<uint, string> ring = new SortedDictionary<uint, string>();
    private readonly int vnodes;
    
    public ConsistentHash(int vnodes)
    {
        this.vnodes = vnodes;
    }

    public void AddNode(string node)
    {
        for (int i = 0; i < vnodes; i++)
        {
            uint hash = Hash(node);
            ring[hash] = node;
        }
        
    }
    
    private uint Hash(string input) {
        byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToUInt32(bytes, 0);    // first 4 bytes as uint
    }
}