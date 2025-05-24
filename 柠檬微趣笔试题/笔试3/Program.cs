class Program
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        Console.WriteLine(IsValid(s) ? "true" : "false");
    }

    // static bool IsValid(string S)
    // {
    //     while (S.Contains("abc"))
    //     {
    //         S = S.Replace("abc", "");
    //     }
    //     return S.Length == 0;
    // }
    
    static public bool IsValid(string S)
    {
        var stack = new Stack<char>();
        foreach (char ch in S)
        {
            stack.Push(ch);
            if (stack.Count >= 3)
            {
                char c = stack.Pop();
                char b = stack.Pop();
                char a = stack.Pop();
                if (a == 'a' && b == 'b' && c == 'c')
                {
                    // 匹配到"abc"，不需要再入栈
                    continue;
                }
                else
                {
                    // 不是"abc"，按原顺序重新入栈
                    stack.Push(a);
                    stack.Push(b);
                    stack.Push(c);
                }
            }
        }
        return stack.Count == 0;
    }

}
