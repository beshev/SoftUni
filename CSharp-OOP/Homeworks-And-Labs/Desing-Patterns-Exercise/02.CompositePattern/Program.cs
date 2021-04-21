using _02.CompositePattern.Models;
using System;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Smart Phone - Redmi Note 9", 380);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("RootBox", 0);
            var truckToy = new SingleGift("Truck Toy", 10);
            var plainToy = new SingleGift("PlainToy",50);
            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            CompositeGift childBox = new CompositeGift("ChildBox", 0);
            var soldierToy = new SingleGift("SoldierToy", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
