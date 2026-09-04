namespace DSAandAlgo.Partition;

public class PartitionLabel
{
    /**
    Partition the string so each letter appears in AT MOST one part.
        Return the sizes.
    "ababcbacadefegdehijhklij" → [9, 7, 8]
    **/
    public IList<int> PartitionLabels(string s)
    {
        int[] maxIndex = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            maxIndex[s[i] - 'a'] = i;
        }

        int maxEnd = 0;
        int start = 0;
        List<int> inx = new List<int>();
        for (int c = 0; c < s.Length; c++)
        {
            maxEnd = Math.Max(maxIndex[s[c] - 'a'], maxEnd);
            if (maxEnd == c)
            {
                inx.Add(c - start + 1);
                start = c + 1;
            }
        }
        return inx;
    }
}