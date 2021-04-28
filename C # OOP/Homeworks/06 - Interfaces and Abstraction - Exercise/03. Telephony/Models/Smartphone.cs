using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class Smartphone : ICaller, IBrowser
    {

        public string Browse(string url)
        {
            if ((url.Any(x => char.IsDigit(x))))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (number.Length == 10 && number.All(d => char.IsDigit(d)))
            {
                return $"Calling... {number}";
            }
            return "Invalid number!";
        }

        public string number { get; private set; }
    }
}
