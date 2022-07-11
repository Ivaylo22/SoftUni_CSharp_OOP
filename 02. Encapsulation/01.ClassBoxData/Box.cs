using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length 
        {
            get 
            { 
            return this.length;
            }
            private set 
            {
                if (value <= 0) 
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
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
                    throw new ArgumentException("Width cannot be zero or negative.");
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
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double SurfaceArea() 
        {
            double surface = 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return surface;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurface = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return lateralSurface;
        }

        public double Volume() 
        {
            double volume = this.Length * this.Height * this.Width;
            return volume;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Surface Area - {this.SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
        }

    }
}
