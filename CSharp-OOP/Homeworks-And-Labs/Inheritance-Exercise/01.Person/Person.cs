using System.Text;

namespace Person
{
    public class Person
    {

        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");
            return sb.ToString().TrimEnd();
        }
    }
}
