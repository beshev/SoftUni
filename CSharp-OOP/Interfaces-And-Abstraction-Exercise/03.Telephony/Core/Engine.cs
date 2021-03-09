using System;

using _03.Telephony.Common;
using _03.Telephony.Models;
using _03.Telephony.Models.Contracts;

namespace _03.Telephony.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] sites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CallAllNumbers(numbers);

            BrowsingAllSites(sites);


        }

        private void CallAllNumbers(string[] numbers)
        {
            ICalling smartphone = new Smartphone();
            ICalling stationaryPhone = new StationaryPhone();
            foreach (var number in numbers)
            {
                if (IsNotDigit(number))
                {
                    Console.WriteLine(GlobalConst.InvalindNumberArgExeption);
                }
                else
                {
                    if (number.Length == 10)
                    {
                        smartphone.Calling(number);
                    }
                    else if (number.Length == 7)
                    {
                        stationaryPhone.Calling(number);
                    }
                }
            }
        }

        private void BrowsingAllSites(string[] sites)
        {
            IBrowsing smartphone = new Smartphone();
            foreach (var site in sites)
            {
                if (HaveDigit(site))
                {
                    Console.WriteLine(GlobalConst.InvalidUrlArgExeption);
                }
                else
                {
                    smartphone.Browsing(site);
                }
            }
        }

        private bool HaveDigit(string site)
        {
            foreach (var @char in site)
            {
                if (char.IsDigit(@char))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNotDigit(string number)
        {
            foreach (var digit in number)
            {
                if (char.IsDigit(digit) == false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
