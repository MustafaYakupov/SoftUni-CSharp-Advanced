using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01ClassBoxData.Models
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Lenght)} cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double surfaceArea = (2 * this.Lenght * this.Width) + (2 * this.Lenght * this.Height) + (2 * this.Width * this.Height);

            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;

            return lateralSurfaceArea;
        }

        public double Volume()
        {
            double volume = this.Lenght * this.Width * this.Height;

            return volume;
        }
    }
}
