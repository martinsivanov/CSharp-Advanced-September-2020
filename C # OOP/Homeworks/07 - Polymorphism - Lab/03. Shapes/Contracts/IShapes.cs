using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Contracts
{
    public interface IShapes
    {
        double CalculatePerimeter();
        double CalculateArea();
        string Draw();
    }
}
