using System.Collections.Generic;

namespace CustomStack
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        public void AddRange(Stack<string> stack)
        {
            while (stack.Count > 0)
            {
                base.Push(stack.Pop());
            }
        }
    }
}
