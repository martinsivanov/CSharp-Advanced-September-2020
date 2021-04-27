using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public int CalculateDifference(string dateOne, string dateTwo)
        {
            var dateOneArr = dateOne.Split().Select(int.Parse).ToArray();

            DateTime dateTimeFirst = new DateTime(dateOneArr[0], dateOneArr[1], dateOneArr[2]);

            var dateTwoArr = dateTwo.Split().Select(int.Parse).ToArray();

            DateTime dateTimeSecond = new DateTime(dateTwoArr[0], dateTwoArr[1], dateTwoArr[2]);

            return Math.Abs((dateTimeFirst - dateTimeSecond).Days);
        }
    }
}
