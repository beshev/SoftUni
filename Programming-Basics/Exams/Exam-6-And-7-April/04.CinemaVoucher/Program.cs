using System;

namespace _04.CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int moneyHave = int.Parse(Console.ReadLine());
            string voucher = Console.ReadLine();
            int counterTickets = 0;
            int counterProduct = 0;

            while (voucher != "End")
            {
                int priceForProduct = 0;
                if (voucher.Length > 8)
                {
                    priceForProduct += voucher[0] + voucher[1];
                }
                else
                {
                    priceForProduct += voucher[0];
                }
                if (moneyHave < priceForProduct)
                {
                    break;
                }
                else
                {
                    moneyHave -= priceForProduct;
                    if (voucher.Length > 8 )
                    {
                        counterTickets++;
                    }
                    else
                    {
                        counterProduct++;
                    }
                }
                voucher = Console.ReadLine();
            }
            Console.WriteLine($"{counterTickets}");
            Console.WriteLine($"{counterProduct}");
        }
    }
}
