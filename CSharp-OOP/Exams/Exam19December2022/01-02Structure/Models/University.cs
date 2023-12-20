using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private int id;
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;
        private string[] allowedCategories = new string[]
            {"Technical", "Economical", "Humanity"};

        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;
            this.requiredSubjects = requiredSubjects.ToList();
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                this.name = value;
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }

            private set
            {
                if (!allowedCategories.Contains(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CategoryNotAllowed, value));
                }

                this.category = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CapacityNegative));
                }

                this.capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects
        {
            get
            {
                return this.requiredSubjects.AsReadOnly();
            }
        }
    }
}
