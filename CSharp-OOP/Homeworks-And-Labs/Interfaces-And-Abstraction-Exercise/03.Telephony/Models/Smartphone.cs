using System;
using System.Text.RegularExpressions;

using _03.Telephony.Common;
using _03.Telephony.Models.Contracts;

namespace _03.Telephony.Models
{
    public class Smartphone : ICalling, IBrowsing
    {
        public void Browsing(string site)
        {
            Console.WriteLine(string.Format(GlobalConst.BrowsingMsg, site));
        }

        public void Calling(string number)
        {
            Console.WriteLine(string.Format(GlobalConst.CallingFromSmatphoneMsg, number));
        }
    }
}
