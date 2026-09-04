namespace DSAandAlgo.Strings;

public class DiffWaysToCompute
{
    public IList<int> DiffWaysToComputed(string expression) {
        
    }

    int DiffWaysToComputed(string expression, int index, List<int> results)
    {
        if (index < 0 || index >= expression.Length) return 0;
        var chard = expression[index];
        for (int start = index; start < expression.Length; start++)
        {
            if (chard == '+' || chard == '-' || chard == '*' || chard == '/')
            {
                var l = DiffWaysToComputed(expression, start  - 1, results);
                var r = DiffWaysToComputed(expression, start + 1, results);
            }
        }
    }
}