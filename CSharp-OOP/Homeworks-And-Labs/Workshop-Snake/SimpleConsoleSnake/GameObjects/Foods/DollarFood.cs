namespace SimpleConsoleSnake.GameObjects.Foods
{
    public class DollarFood : Food
    {
        private const char foodSymbol = '$';
        private const int foodPoints = 2;

        public DollarFood() : base(foodSymbol, foodPoints)
        {
        }
    }
}
