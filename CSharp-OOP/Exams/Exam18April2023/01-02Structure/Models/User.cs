using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private double rating = 0;
        private string drivingLicenseNumber;
        private bool isBlocked = false;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }

                this.firstName = value;
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
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }

                this.lastName = value;
            }
        }
        public string DrivingLicenseNumber
        {
            get
            {
                return this.drivingLicenseNumber;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }

                this.drivingLicenseNumber = value;
            }
        }

        public double Rating
        {
            get
            {
                return this.rating;
            }

            private set
            {
                this.rating = value;
            }
        }


        public bool IsBlocked
        {
            get
            {
                return this.isBlocked;
            }

            private set
            {
                this.isBlocked = value;
            }
        }
        public void IncreaseRating()
        {
            this.rating += 0.5;

            if (this.rating >= 10.00)
            {
                this.rating = 10.00;
            }
        }

        public void DecreaseRating()
        {
            this.rating -= 2.00;

            if (this.rating <= 0.00)
            {
                this.rating = 0.00;
                IsBlocked = true;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}";
        }
    }
}
