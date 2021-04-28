using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Common
{
    public static class GlobalConstants
    {
        public static string ExeptionMassageForInvalidName = "Name cannot be empty";
        public static string ExeptionMassageForNegativeMoney = "Money cannot be negative";
        public static string ExeptionMassageNotEnoughtMoneyForProduct =
            "{0} can't afford {1}";
    }
}
