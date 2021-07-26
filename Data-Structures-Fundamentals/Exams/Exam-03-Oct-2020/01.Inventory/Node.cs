namespace _01.Inventory
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> leftChild { get; set; }

        public Node<T> rightChild { get; set; }
    }
}
