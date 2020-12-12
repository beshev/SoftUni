using System;

namespace _08.FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print Input;
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double num = double.Parse(Console.ReadLine());
            double price = 0;
            //Price for fruits from Monday to friday;
            //плод      banana  apple  orange  grapefruit  kiwi  pineapple  grapes
            //цена       2.50   1.20    0.85     1.45      2.70    5.50      3.85
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":                
                    switch (fruit)
                    {
                        case "banana":
                            price = 2.50;
                            break;
                        case "apple":
                            price = 1.20;
                            break;
                        case "orange":
                            price = 0.85;
                            break;
                        case "grapefruit":
                            price = 1.45;
                            break;
                        case "kiwi":
                            price = 2.70;
                            break;
                        case "pineapple":
                            price = 5.5;
                            break;
                        case "grapes":
                            price = 3.85;
                            break;                            
                    }                   
                    break;
                // Price for fruits in Saturday and Sunday
                case "Saturday":
                case "Sunday":
                    switch (fruit)
                    {
                        case "banana":
                            price = 2.70;
                            break;
                        case "apple":
                            price = 1.25;
                            break;
                        case "orange":
                            price = 0.90;
                            break;
                        case "grapefruit":
                            price = 1.60;
                            break;
                        case "kiwi":
                            price = 3;
                            break;
                        case "pineapple":
                            price = 5.6;
                            break;
                        case "grapes":
                            price = 4.20;
                            break;
                    }                    
                    break;


            }
            // Print Output
            price *= num;
            bool days = day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday" || day == "Sunday" || day == "Saturday";
            bool fruits = fruit == "banana" || fruit == "apple" || fruit == "orange" || fruit == "grapefruit" || fruit == "kiwi" || fruit == "pineapple" || fruit == "grapes";
            if (days && fruits) 
            {
                Console.WriteLine($"{price:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
