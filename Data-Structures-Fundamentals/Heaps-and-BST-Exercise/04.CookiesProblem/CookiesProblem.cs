namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            MinHeap<int> minHeap = new MinHeap<int>(cookies);

            int count = 0;

            while (minHeap.Size > 0)
            {
                if (minHeap.Peek() > k)
                {
                    return count;
                }

                if (minHeap.Size == 1)
                {
                    break;
                }

                var first = minHeap.Dequeue();
                var second = minHeap.Dequeue();

                var result = first + (2 * second);
                count++;

                minHeap.Add(result);
            }

            return -1;
        }
    }
}
