using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class StationaryPhone : ICaller
    {
        private string number;

        public StationaryPhone(string number)
        {
            this.Number = number;
        }

        public StationaryPhone()
        {
        }

        public string Call(string number)
        {
            if (!(number.Length == 7 && number.All(d => char.IsDigit(d))))
            {
                throw new Exception("Invalid number!");
            }
            return $"Dialing... {number}";
        }
        public string Number
        {
            get
            {
                return this.number;
            }
            private set
            {
                this.number = value;
            }
        }
    }
}
