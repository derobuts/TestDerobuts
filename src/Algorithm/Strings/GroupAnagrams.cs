namespace DSAandAlgo.Strings;

/// <summary>
/// LeetCode 49 - Group Anagrams.
/// Given an array of strings, group the anagrams together. Two strings are
/// anagrams if they contain the same characters with the same multiplicities.
/// The order of groups and of strings within a group does not matter.
/// </summary>
/// <example>
/// Input:  ["eat","tea","tan","ate","nat","bat"]
/// Output: [["eat","tea","ate"], ["tan","nat"], ["bat"]]
/// </example>
/// <remarks>
/// Approach: canonicalize each word by sorting its characters; group by the
/// canonical key in a dictionary. O(n * k log k) where k is the max word length.
/// </remarks>
public class GroupAnagrams
{
    public IList<IList<string>> Solve(string[] strs)
    {
        var groups = new Dictionary<string, List<string>>();
        foreach (var word in strs)
        {
            var chars = word.ToCharArray();
            Array.Sort(chars);
            var key = new string(chars);

            if (!groups.TryGetValue(key, out var bucket))
            {
                bucket = new List<string>();
                groups[key] = bucket;
            }
            bucket.Add(word);
        }

        return groups.Values.Cast<IList<string>>().ToList();
    }
}
