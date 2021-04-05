using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            for (int i = 1; i <= 10; i++)
            {
                list.AddTail(new Node(i));
            }
            int[] array = list.ToArray();
            Console.WriteLine(string.Join(' ',array));
            Console.WriteLine(string.Join(Environment.NewLine,array));
            Console.WriteLine(string.Join(' ', array));
        }
    }
}
