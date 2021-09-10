namespace HashTable
{
   public class StartUp
    {
        static void Main()
        {
            HashTable.HashTable<int, string> keyValues = new HashTable.HashTable<int, string> { { 555, "Peter" } };
        }
    }
}
