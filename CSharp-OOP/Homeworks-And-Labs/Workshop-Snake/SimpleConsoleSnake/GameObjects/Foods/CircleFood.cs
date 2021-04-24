namespace SimpleConsoleSnake.GameObjects.Foods
{
    public class CircleFood : Food
    {
        private const char foodSymbol = 'O';
        private const int foodPoints = 3;

        public CircleFood() : base(foodSymbol, foodPoints)
        {
        }
    }
}
