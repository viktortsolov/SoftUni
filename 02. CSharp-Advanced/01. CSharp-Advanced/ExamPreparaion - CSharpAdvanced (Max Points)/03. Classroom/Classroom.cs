using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return this.students.Count;
            }
        }

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = this.students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (students.Contains(student))
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            var studentWithSubject = this.students.Where(x => x.Subject == subject);

            if (studentWithSubject.Count() == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Subject: {subject}");
            stringBuilder.AppendLine("Students:");
            foreach (var item in studentWithSubject)
            {
                stringBuilder.AppendLine($"{item.FirstName} {item.LastName}");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = this.students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            return student;
        }

    }
}
