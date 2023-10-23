using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public bool AddChild(Child child)
        {
            if (this.Registry.Count < this.Capacity)
            {
                this.Registry.Add(child);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveChild(string fullName)
        {
            string[] name = fullName.Split(' ');
            string currentFirstName = name[0];
            string currentLastName = name[1];

            var childToRemove = Registry
                .Where(x => x.FirstName == currentFirstName && x.LastName == currentLastName)
                .FirstOrDefault();

            if (this.Registry.Contains(childToRemove))
            {
                this.Registry.Remove(childToRemove);

                return true;
            }
            else return false;
        }

        public int ChildrenCount()
        {
            return this.Registry.Count;

        }

        public Child GetChild(string fullName)
        {
            string[] name = fullName.Split(' ');
            string currentFirstName = name[0];
            string currentLastName = name[1];

            var childToFind = Registry
                .Where(x => x.FirstName == currentFirstName && x.LastName == currentLastName)
                .FirstOrDefault();

            if (this.Registry.Contains(childToFind))
            {
                return childToFind;
            }
            else return null;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Registered children in {this.Name}:");

            foreach (var child in this.Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
