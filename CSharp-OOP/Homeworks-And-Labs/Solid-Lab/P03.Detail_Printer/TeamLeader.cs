using System;
using System.Collections.Generic;

using P03.DetailPrinter;

namespace P03.Detail_Printer
{
    class TeamLeader : Employee
    {
        private ICollection<string> teamMembers;

        public TeamLeader(string name,ICollection<string> memebers) : base(name)
        {
            this.teamMembers = memebers;
        }
    }
}
