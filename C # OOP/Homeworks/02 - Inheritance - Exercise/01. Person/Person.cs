using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Person
    {
        private const int PERSON_MIN_AGE = 0;

        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }
        public virtual int Age 
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value >= PERSON_MIN_AGE)
                {
                    this.age = value;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
