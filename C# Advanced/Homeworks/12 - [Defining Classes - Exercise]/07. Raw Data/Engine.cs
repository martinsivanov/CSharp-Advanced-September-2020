﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
   public class Engine
    {
        public int engineSpeed;
        public int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }


    }
}
