using System.Text;

namespace DSAandAlgo.Strings;

public class MinRemoveToMakeValid
{
    public string MinRemoveMakeValid(string s) {
        var indexStack = new Stack<int>();
        var toRemove = new HashSet<int>();
    
        // First pass: find unmatched ')'
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                indexStack.Push(i);
            } else if (s[i] == ')') {
                if (indexStack.Count == 0) {
                    toRemove.Add(i);  // Extra ')'
                } else {
                    indexStack.Pop();
                }
            }
        }
    
        // Remaining '(' are unmatched
        while (indexStack.Count > 0) {
            toRemove.Add(indexStack.Pop());
        }
    
        // Build result
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++) {
            if (!toRemove.Contains(i)) sb.Append(s[i]);
        }
    
        return sb.ToString();
    }
}