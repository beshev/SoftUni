namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> result = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                char current = parentheses[i];

                if (current == '(' || current == '{' || current == '[')
                {
                    result.Push(current);
                }
                else
                {

                    if (result.Count == 0 && i < parentheses.Length)
                    {
                        return false;
                    }

                    if (result.Peek() == '(' && current == ')')
                    {
                        result.Pop();
                    }
                    else if (result.Peek() == '{' && current == '}')
                    {
                        result.Pop();
                    }
                    else if (result.Peek() == '[' && current == ']')
                    {
                        result.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
