using System.Text;

namespace DSAandAlgo.Intervals;

/**
 * Rearrange String k Distance Apart (LC 358)
 *
 * Rearrange s so equal characters sit at least k apart, or return "".
 *
 * GREEDY + COOLDOWN: at every position emit the character with the most
 * remaining copies (that is the one most at risk of running out of room).
 * Once emitted it goes into a FIFO cooldown queue tagged with the index at
 * which it becomes legal again (current index + k), and only re-enters the
 * heap after that. If the heap empties while the string is incomplete, no
 * arrangement exists.
 *
 * Time:  O(n log 26) = O(n)
 * Space: O(26) = O(1)
 */
public class ReArrangeStringKDistance
{
    public string Solve(string s, int k)
    {
        if (k <= 1) return s;

        var counts = new int[26];
        foreach (char c in s)
        {
            counts[c - 'a']++;
        }

        // max-heap on remaining count (negate for .NET's min-heap)
        var available = new PriorityQueue<char, int>();
        for (int i = 0; i < 26; i++)
        {
            if (counts[i] > 0)
            {
                available.Enqueue((char)('a' + i), -counts[i]);
            }
        }

        // (character, index at which it may be reused)
        var cooldown = new Queue<(char Ch, int ReadyAt)>();
        var sb = new StringBuilder(s.Length);

        while (sb.Length < s.Length)
        {
            // release everything whose cooldown has expired
            while (cooldown.Count > 0 && cooldown.Peek().ReadyAt <= sb.Length)
            {
                char ready = cooldown.Dequeue().Ch;
                available.Enqueue(ready, -counts[ready - 'a']);
            }

            if (available.Count == 0) return "";   // starved - impossible

            char ch = available.Dequeue();
            sb.Append(ch);
            counts[ch - 'a']--;

            if (counts[ch - 'a'] > 0)
            {
                cooldown.Enqueue((ch, sb.Length + k - 1));
            }
        }

        return sb.ToString();
    }
}
