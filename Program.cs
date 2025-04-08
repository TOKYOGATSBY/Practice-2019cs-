using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();

        int len = 2 * n;
        int[] result = new int[n];
        int[] match = new int[len];
        Array.Fill(match, -1);

        Stack<int> st = new Stack<int>();

        for (int i = 0; i < len; ++i)
        {
            if (st.Count == 0)
            {
                st.Push(i);
            }
            else
            {
                int j = st.Peek();
                char a = s[i], b = s[j];
                if (char.ToUpper(a) == char.ToUpper(b) && char.IsUpper(a) != char.IsUpper(b))
                {
                    match[i] = j;
                    match[j] = i;
                    st.Pop();
                }
                else
                {
                    st.Push(i);
                }
            }
        }

        if (st.Count != 0)
        {
            Console.WriteLine("Impossible");
            return;
        }

        int hunter_id = 0, ghost_id = 0;
        int[] hunter_num = new int[len];
        int[] ghost_num = new int[len];

        for (int i = 0; i < len; ++i)
        {
            if (char.IsUpper(s[i]))
                hunter_num[i] = hunter_id++;
            else
                ghost_num[i] = ghost_id++;
        }

        for (int i = 0; i < len; ++i)
        {
            if (char.IsUpper(s[i]))
            {
                int j = match[i];
                result[hunter_num[i]] = ghost_num[j] + 1;
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
}

