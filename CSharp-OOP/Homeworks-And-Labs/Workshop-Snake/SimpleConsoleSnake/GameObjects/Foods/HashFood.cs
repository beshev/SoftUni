namespace SimpleConsoleSnake.GameObjects.Foods
{
    public class HashFood : Food
    {
        private const char foodSymbol = '#';
        private const int foodPoints = 1;

        public HashFood() : base(foodSymbol, foodPoints)
        {
        }
    }
}
