using System;

namespace _11FishLand
{
    class Program
    {
        static void Main(string[] args)
        {
            // Какво знаем - Цена на ;  Цаца , Скумрия , Миди / Количество на ; Паламуд , Сафрид , Миди 
            // Какво Трябва Да Разберем - Цената на Паламуд , Сафрид , Миди

            double priceMacakerl = double.Parse(Console.ReadLine());
            double priceToy = double.Parse(Console.ReadLine());
            double kilogramBonito = double.Parse(Console.ReadLine());
            double kilogramHorse = double.Parse(Console.ReadLine());
            int kilogramShell = int.Parse(Console.ReadLine());

            double priceBonito = priceMacakerl + (0.6 * priceMacakerl);
            double priceHorse = priceToy + (0.8 * priceToy);

            double Shell = kilogramShell * 7.50;
            double Bonito = priceBonito * kilogramBonito;
            double horseMake = priceHorse * kilogramHorse;
            double end = Shell + Bonito + horseMake;

            Console.WriteLine($"{end:f2}");






        }
    }
}
