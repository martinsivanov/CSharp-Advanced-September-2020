using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const double MIN_SIDE = 0;
        private const string ARGUMENT_EXEPTION_MESSAGE = "{0} cannot be zero or negative.";
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
                if (value <= MIN_SIDE)
                {
                    throw new ArgumentException(string.Format(ARGUMENT_EXEPTION_MESSAGE, nameof(this.Lenght)));
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
                if (value <= MIN_SIDE)
                {
                    throw new ArgumentException(string.Format(ARGUMENT_EXEPTION_MESSAGE, nameof(this.Width)));
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
                if (value <= MIN_SIDE)
                {
                    throw new ArgumentException(string.Format(ARGUMENT_EXEPTION_MESSAGE, nameof(this.Height)));
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return (2 * this.Lenght * this.Width)
                + (2 * this.Lenght * this.Height) +
                (2 * this.Width * this.Height);
        }
        public double LateralSurfaceArea()
        {
            return (2 * this.Lenght * this.Height) + (2 * this.Width * this.Height);
        }
        public double Volume()
        {
            return this.Lenght * this.Width * this.Height;
        }

    }
}
