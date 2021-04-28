using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Models
{
    public class Seat : Car, ICar
    {
        public Seat(string model, string color) 
            : base(model, color)
        {
        }
    }
}
