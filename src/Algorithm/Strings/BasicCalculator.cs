namespace DSAandAlgo.Strings;

public class BasicCalculator
{
    public int Calculate(string s) {
        var stack = new Stack<int>();
        int num = 0;
        char op = '+';
    
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
        
            if (char.IsDigit(c)) {
                num = num * 10 + (c - '0');
            }
        
            // At operator or end of string
            if ((!char.IsDigit(c) && c != ' ') || i == s.Length - 1) {
                if (op == '+') stack.Push(num);
                else if (op == '-') stack.Push(-num);
                else if (op == '*') stack.Push(stack.Pop() * num);
                else if (op == '/') stack.Push(stack.Pop() / num);
            
                op = c;
                num = 0;
            }
        }
    
        return stack.Sum();
    }
    
    private int Precedence(char op) {
        if (op == '*' || op == '/') return 2;
        if (op == '+' || op == '-') return 1;
        return 0;
    }
    
}