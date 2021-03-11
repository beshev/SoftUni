using System;
using System.Collections.Generic;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();
            soldiers.Add(new Engineer("asd","asd",2m,2));
            foreach (var item in soldiers)
            {
                Console.WriteLine(item);
            }
        }
    }

    interface ISoldier
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public string FirstName { get; set; }

        public string ToString();
    }

    class Soldier : ISoldier
    {
        public Soldier(string name,string age,decimal salary)
        {

        }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string ToString()
        {
            return "In the soldier";
        }
    }

    class Private : Soldier
    {
        public Private(string name, string age, decimal salary,int rate) : base(name, age, salary)
        {
        }

        public override string ToString()
        {
            return "In the Private";
        }
    }
    class Engineer : Private
    {
        public Engineer(string name, string age, decimal salary, int rate) : base(name, age, salary, rate)
        {
        }

        public override string ToString()
        {
            return "In the Engineer";
        }
    }
}
