using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> allBoxesInfo = new List<Box>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] itemInfo = input.Split();
                Box currentBoxInfo = new Box();

                currentBoxInfo.SerialNumber = itemInfo[0];
                currentBoxInfo.Item.Name = itemInfo[1];
                currentBoxInfo.Item.Price = decimal.Parse(itemInfo[3]);
                currentBoxInfo.Quantity = int.Parse(itemInfo[2]);
                currentBoxInfo.PriceBox = currentBoxInfo.Quantity * currentBoxInfo.Item.Price;
                allBoxesInfo.Add(currentBoxInfo);
                input = Console.ReadLine();
            }

            foreach (var box in allBoxesInfo.OrderBy(x => -x.PriceBox))
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");
            }


        }
    }

    public class Item
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }

    public class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal PriceBox { get; set; }
    }
}



