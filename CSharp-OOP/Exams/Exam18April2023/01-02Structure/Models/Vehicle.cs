using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel = 100;
        private bool isDamaged = false;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }

                this.brand = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }

                this.model = value;
            }
        }

        public double MaxMileage
        {
            get
            {
                return this.maxMileage;
            }

            private set
            {
                this.maxMileage = value;
            }
        }

        public string LicensePlateNumber
        {
            get
            {
                return this.licensePlateNumber;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }

                this.licensePlateNumber = value;
            }
        }

        public int BatteryLevel
        {
            get
            {
                return this.batteryLevel;
            }

            private set
            {
                this.batteryLevel = value;
            }
        } 

        public bool IsDamaged
        {
            get
            {
                return this.isDamaged;
            }

            private set
            {
                this.isDamaged = value;
            }
        }
        public void Drive(double mileage)
        {
            double percentageToReduce = mileage / this.MaxMileage;
            double percentageUsed = Math.Round(percentageToReduce * 100);
            this.BatteryLevel -= (int)percentageUsed;

            if (this.GetType() == typeof(CargoVan))
            {
                this.BatteryLevel -= 5;
            }
        }
        public void Recharge()
        {
            this.BatteryLevel = 100;
        }

        public void ChangeStatus()
        {
            if (this.IsDamaged == true)
            {
                this.IsDamaged = false;
            }
            else
            {
                this.IsDamaged = true;
            }
        }

        public override string ToString()
        {
            return $"{this.Brand} {this.Model} License plate: {this.LicensePlateNumber} Battery: {this.BatteryLevel}% Status: {(IsDamaged ? "damaged" : "OK")}";
        }
    }
}
