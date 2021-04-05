using System;
using System.Text.RegularExpressions;

using _03.Telephony.Common;
using _03.Telephony.Models.Contracts;

namespace _03.Telephony.Models
{
    public class StationaryPhone : ICalling
    {
        public void Calling(string number)
        {
            Console.WriteLine(string.Format(GlobalConst.CallingFromStationaryPhoneMsg, number));
        }
    }
}
