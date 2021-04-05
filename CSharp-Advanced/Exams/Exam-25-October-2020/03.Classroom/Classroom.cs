using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    class Classroom
    {
        private List<Student> students;

        private int capacity;

        public Classroom(int capacity)
        {
            this.capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get { return this.capacity; } }

        public int Count { get { return this.students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student currentStudent =
               this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (currentStudent != null)
            {
                this.students.Remove(currentStudent);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            Student[] result = this.students.FindAll(s => s.Subject == subject).ToArray();
            if (result.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var s in result)
                {
                    sb.AppendLine($"{s.FirstName} {s.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            return $"No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
