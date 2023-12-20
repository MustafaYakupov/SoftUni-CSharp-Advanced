using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private int id;
        private string firtsName;
        private string lastName;
        private List<int> coveredExams;
        private IUniversity university;

        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;
            coveredExams = new List<int>();
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

        public string FirstName
        {
            get
            {
                return this.firtsName;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                this.firtsName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                this.lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams
        { 
            get
            {
                return this.coveredExams.AsReadOnly();
            }
        }

        public IUniversity University
        {
            get
            {
                return this.university;
            }
        }

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.university = university;
        }
    }
}
