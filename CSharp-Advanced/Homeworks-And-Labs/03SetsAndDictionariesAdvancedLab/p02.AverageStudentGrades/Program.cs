using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> marks = new Dictionary<string, List<double>>();

            double averageGrade = 0;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string studentName = input[0];
                double studentGrade = double.Parse(input[1]);

                if (!marks.ContainsKey(studentName))
                {
                    marks[studentName] = new List<double>();
                }
                
                marks[studentName].Add(studentGrade);
            }

            foreach (var kvp in marks)
            {
                var name = kvp.Key;
                var currentMarks = kvp.Value;
                var averageMark = currentMarks.Average();

                Console.WriteLine($"{name} -> {string.Join(" ", currentMarks.Select(grade => grade.ToString("F2")))} (avg: {averageMark:F2})");
            }
        }
    }
}
