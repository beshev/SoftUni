using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            MyFamily = new List<Person>();
        }

        public List<Person> MyFamily { get; set; }

        public void AddMember(Person member)
        {
            MyFamily.Add(member);
        }

        public Person GetOldestMember()
        {
            return MyFamily.OrderByDescending(x => x.Age).FirstOrDefault(x => x.Age == x.Age);
        }
    }
}
