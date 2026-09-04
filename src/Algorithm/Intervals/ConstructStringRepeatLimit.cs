using System.Text;

namespace DSAandAlgo.Intervals;

public class ConstructStringRepeatLimit
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        var count = new int [26];
        foreach (var chars in s)
        {
            count[chars - 'a']++;
        }
        
        var maxHeap = new PriorityQueue<char, int>();
        foreach (var chard in s)
        {
            maxHeap.Enqueue(chard, -(chard - 'a'));
        }

        var stringB = new StringBuilder();
        var queue = new Queue<(char, int)>();
        while (maxHeap.Count > 0)
        {
            while (queue.Count > 0 && queue.Peek().Item2 >= stringB.Length)
            {
                var chard = queue.Dequeue();
                maxHeap.Enqueue(chard.Item1, -(chard.Item1 - 'a'));
            }
            var chardeq = maxHeap.Dequeue();
            while (count[chardeq - 'a']-- > 0)
            {
                stringB.Append(chardeq);
            }

            if (count[chardeq] > 0)
            {
                queue.Enqueue((chardeq, stringB.Length + 1));
            }
        }
        return stringB.ToString();
    }
}