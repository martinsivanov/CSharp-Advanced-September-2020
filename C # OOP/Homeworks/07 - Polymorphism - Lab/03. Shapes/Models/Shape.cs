using Shapes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    public abstract class Shape : IShapes
    {

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

        public virtual string Draw()
        {
            return "Drawing ";
        }
    }
}
