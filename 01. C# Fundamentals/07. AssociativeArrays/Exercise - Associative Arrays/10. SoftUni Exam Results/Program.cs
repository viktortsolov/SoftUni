using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            var students = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] cmdArg = input.Split("-");
                string user = cmdArg[0];

                if (cmdArg.Length > 2)
                {
                    string language = cmdArg[1];
                    int points = int.Parse(cmdArg[2]);

                    if (!students.ContainsKey(user))
                    {
                        students.Add(user, points);
                    }
                    else
                    {
                        if (students[user] < points)
                        {
                            students[user] = points;
                        }
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;
                }
                else
                {
                    students.Remove(user);
                }
            }

            Console.WriteLine("Results:");
            foreach (var student in students.OrderByDescending(x => x.Value).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
