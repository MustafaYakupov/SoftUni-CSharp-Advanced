using System;
using System.Collections.Generic;
using System.Linq;

namespace P02AverageStudentGrades
{
    class P02AverageStudentGrades
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            var studentsDictionary = new Dictionary<string, List<double>>();
            var grades = new List<double>();

            for (int i = 0; i < inputs; i++)
            {
                string[] students = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = students[0];
                double grade = double.Parse(students[1]);

                if (studentsDictionary.ContainsKey(name) == false)
                {
                    grades = new List<double>();
                    grades.Add(grade);
                    studentsDictionary.Add(name, grades);
                }
                else
                {
                    studentsDictionary[name].Add(grade);
                }
            }

            foreach (var kvp in studentsDictionary)
            {
                Console.Write($"{kvp.Key} -> ");
                foreach (var grade in kvp.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
