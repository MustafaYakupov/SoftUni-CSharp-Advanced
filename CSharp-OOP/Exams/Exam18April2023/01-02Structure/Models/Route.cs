using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double length;
        private int routeId;
        private bool isLocked = false;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Length = length;
            this.RouteId = routeId;
        }

        public string StartPoint
        {
            get
            {
                return this.startPoint;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                }

                this.startPoint = value;
            }
        }
        public string EndPoint
        {
            get
            {
                return this.endPoint;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }

                this.endPoint = value;
            }
        }

        public double Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }

                this.length = value;
            }
        }

        public int RouteId
        {
            get
            {
                return this.routeId;
            }

            private set
            {
                this.routeId = value;
            }
        }

        public bool IsLocked
        {
            get
            {
                return this.isLocked;
            }

            private set
            {
                this.isLocked = value;
            }
        }

        public void LockRoute()
        {
            this.IsLocked = true;
        }
    }
}
