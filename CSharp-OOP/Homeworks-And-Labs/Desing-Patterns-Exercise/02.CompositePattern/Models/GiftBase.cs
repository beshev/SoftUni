namespace _02.CompositePattern.Models
{
    public abstract class GiftBase
    {
        protected string _name;
        protected int _price;

        protected GiftBase(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public abstract int CalculateTotalPrice();  
    }
}
