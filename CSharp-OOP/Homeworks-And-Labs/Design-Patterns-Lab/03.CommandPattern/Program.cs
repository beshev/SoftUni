using _03.CommandPattern.Models;
using _03.CommandPattern.Models.Contracts;

namespace _03.CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("Phone",500);

            Execute(modifyPrice, new ProductCommand(product, Enums.PriceAction.Increase, 100));
            Execute(modifyPrice, new ProductCommand(product, Enums.PriceAction.Increase, 50));
            Execute(modifyPrice, new ProductCommand(product, Enums.PriceAction.Decrease, 25));
            System.Console.WriteLine(product);
        }

        private static void Execute(ModifyPrice modifyPrice,ICommand command)
        {
            modifyPrice.SetCommand(command);
            modifyPrice.Invoke();
        }
    }
}
