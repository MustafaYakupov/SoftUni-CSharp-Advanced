using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count
        {
            get
            {
                return this.renovators.Count();
            }
        }

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Type == null)
            {
                return "Invalid renovator's information.";
            }
            else if (this.renovators.Count() >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                this.renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovatorToRemove = this.renovators.Where(x => x.Name == name).FirstOrDefault();

            if (renovatorToRemove == null)
            {
                return false;
            }
            else
            {
                this.renovators.Remove(renovatorToRemove);
                return true;
            }
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> renovatorsToRemove = this.renovators.FindAll(x => x.Type == type);

            if (renovatorsToRemove.Any())
            {
                foreach (var item in renovatorsToRemove)
                {
                    this.renovators.Remove(item);
                }

                return renovatorsToRemove.Count();
            }
            else
            {
                return 0;
            }
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovatorToHire = this.renovators.Where(x => x.Name == name).FirstOrDefault();

            if (renovatorToHire == null)
            {
                return null;
            }
            else
            {
                this.renovators.Where(x => x.Name == name).Select(y => y.Hired = true);
                return renovatorToHire;
            }
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> resultList = this.renovators.FindAll(x => x.Days >= days);

            return resultList;
        }

        public string Report()
        {
            List<Renovator> resultList = this.renovators.FindAll(x => x.Hired == false);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var renovator in resultList)
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
