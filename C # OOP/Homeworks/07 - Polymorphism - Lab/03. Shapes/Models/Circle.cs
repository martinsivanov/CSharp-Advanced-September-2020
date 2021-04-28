using System;
using System.Collections.Generic;
using System.Text;
using Shapes.ErrorMsgExeptions;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception(String.Format(ErrorMessages.INVALID_MSG, value));
                }
                this.radius = value;
            }
        }
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
