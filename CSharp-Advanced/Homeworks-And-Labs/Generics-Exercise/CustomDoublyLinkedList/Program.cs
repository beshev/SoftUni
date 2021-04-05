using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<char> myList = new DoublyLinkedList<char>();
            myList.AddFirst('a');
            myList.AddLast('z');
            myList.AddLast('z');
            myList.AddLast('a');
            myList.AddLast('z');
            myList.AddLast('e');
            myList.AddLast('l');
            myList.AddLast(' ');
            myList.AddLast('z');
            myList.AddLast('e');
            myList.AddLast('l');
            myList.AddLast(' ');
            myList.AddLast('z');
            myList.AddLast('e');
            myList.AddLast('l');
            myList.AddLast(' ');
            myList.AddLast('z');
            myList.AddLast('e');
            myList.AddLast('l');
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
