using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models
        {
            get
            {
                return models.AsReadOnly();
            }
        }

        public void AddModel(IStudent model) 
        {
            models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return models.FirstOrDefault(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] tokens = name.Split(" ");
            string firstName = tokens[0];
            string lastName = tokens[1];

            return models.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
