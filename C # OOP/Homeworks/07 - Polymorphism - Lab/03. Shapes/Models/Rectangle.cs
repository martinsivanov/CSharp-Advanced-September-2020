using System;
using System.Collections.Generic;
using System.Text;
using Shapes.ErrorMsgExeptions;
namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception(String.Format(ErrorMessages.INVALID_MSG, value));
                }
                this.height = value;
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
                    throw new Exception(String.Format(ErrorMessages.INVALID_MSG, value));
                }
                this.width = value;
            }
        }
        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return (2 * this.Height) + (2 * this.Width);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
