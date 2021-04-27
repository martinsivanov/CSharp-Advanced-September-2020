﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    public class Rabbit
    {
        public Rabbit(string name, string species)
        {
            Name = name;
            Species = species;
            this.Available = true;
        }

        //•	Name: string
        //•	Species: string
        //•	Available: bool - true by default

        public string Name { get; set; }
        public string Species { get; set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            return $"Rabbit ({this.Species}): {this.Name}";
        }
    }
}
