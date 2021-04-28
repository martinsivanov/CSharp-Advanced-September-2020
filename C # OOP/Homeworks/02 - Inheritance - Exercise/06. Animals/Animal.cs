using System;
using System.Collections.Generic;
using System.Text;

namespace P06Animals
{
    public abstract class Animal
    {
        private const string ErrorMassage = "Invalid input!";
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMassage);
                }
                 this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 0)
                {

                    throw new ArgumentException(ErrorMassage);
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || 
                    (value != "Male" && value != "Female"))
                {
                    throw new ArgumentException(ErrorMassage);
                }
                this.gender = value;
            }
        }
        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}")
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .AppendLine($"{this.ProduceSound()}");

            return sb.ToString().TrimEnd();
        }
    }
}
