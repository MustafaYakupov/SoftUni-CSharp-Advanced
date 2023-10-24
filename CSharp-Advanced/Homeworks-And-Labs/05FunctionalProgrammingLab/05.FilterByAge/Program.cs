using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05.FilterByAge
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalPeople = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < totalPeople; i++)
            {
                var currentPerson = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var person = new Person
                {
                    Name = currentPerson[0],
                    Age = int.Parse(currentPerson[1])
                };

                people.Add(person);
            }


            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Func<Person, bool> filterPredicate;

            if (condition == "older")
            {
                filterPredicate = p => p.Age >= age;
            }
            else
            {
                filterPredicate = p => p.Age < age;
            }

            string format = Console.ReadLine();

            Func<Person, string> printFunc;

            if (format == "name age")
            {
                printFunc = p => $"{p.Name} - {p.Age}";
            }
            else if (format == "age")
            {
                printFunc = p => $"{p.Age}";
            }
            else
            {
                printFunc = p => $"{p.Name}";
            }

            people
                .Where(filterPredicate)
                .Select(printFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
