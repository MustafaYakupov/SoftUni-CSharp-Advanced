using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private readonly List<int> interfaceStandards;

        protected Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            this.Model = model;
            this.BatteryCapacity = batteryCapacity;
            this.ConvertionCapacityIndex = conversionCapacityIndex;
            this.BatteryLevel = BatteryCapacity;
            this.interfaceStandards = new List<int>();
        }

        public string Model
        {
            get => model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }

                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }

                batteryCapacity = value;
            }
        }

        public int BatteryLevel
        {
            get => batteryLevel;
            set
            {
                this.batteryLevel = value;
            }
        }

        public int ConvertionCapacityIndex
        {
            get => convertionCapacityIndex;
            set
            {
                this.convertionCapacityIndex = value;
            }
        }

        public IReadOnlyCollection<int> InterfaceStandards
        {
            get
            {
                return this.interfaceStandards.AsReadOnly();
            }
        }

        public void Eating(int minutes)
        {
            int energyProducedPerMinute = this.ConvertionCapacityIndex * minutes;

            this.batteryLevel += energyProducedPerMinute;

            if (this.BatteryLevel > this.BatteryCapacity)
            {
                this.batteryLevel = this.BatteryCapacity;
            }
        }
        public void InstallSupplement(ISupplement supplement)
        {
            this.interfaceStandards.Add(supplement.InterfaceStandard);
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.batteryLevel -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (this.batteryLevel >= consumedEnergy)
            {
                this.batteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.GetType().Name} {this.Model}:");
            sb.AppendLine($"--Maximum battery capacity: {this.BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {this.BatteryLevel}");
            if (this.InterfaceStandards.Count > 0)
            {
                sb.AppendLine($"--Supplements installed: {String.Join(" ", InterfaceStandards)}");
            }
            else
            {
                sb.AppendLine($"--Supplements installed: none");
            }

            return sb.ToString().Trim();
        }
    }
}
