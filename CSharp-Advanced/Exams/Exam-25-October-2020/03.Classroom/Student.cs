using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    class Student
    {
        public Student(string firstName,string lastName,string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Subject { get; }

        public override string ToString()
        {
            return $"Student: First Name = {FirstName}, Last Name = {LastName}, Subject = {Subject}";
        }
    }
}
