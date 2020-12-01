﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < number; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string firstName = tokens[0];
                string lastName = tokens[1];
                double grade = double.Parse(tokens[2]);

                Student student = new Student(firstName, lastName, grade);

                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, students));
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}
