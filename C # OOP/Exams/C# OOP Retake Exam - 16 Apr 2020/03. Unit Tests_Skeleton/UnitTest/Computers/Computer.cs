namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Computer
    {
		private string name;
        private List<Part> parts;

        public Computer(string name)
        {
            //TEST DONE
            this.Name = name;

            this.parts = new List<Part>();
        }

		public string Name
		{
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //TEST DONE
                    throw new ArgumentNullException(nameof(this.Name), "Name cannot be null or empty!");
                }
                //TEST DONE
                this.name = value;
            }
		}
        //TEST DONE
        public IReadOnlyCollection<Part> Parts
            => this.parts.AsReadOnly();

        //TEST DONE
        public decimal TotalPrice
            => this.Parts.Sum(x => x.Price);

        public void AddPart(Part part)
        {
            if (part == null)
            {//TEST DONE
                throw  new InvalidOperationException("Cannot add null!");
            }
            //TEST DONE
            this.parts.Add(part);
        }
        public bool RemovePart(Part part)
            => this.parts.Remove(part); //TEST DONE

        public Part GetPart(string partName) //TEST DONE
            => this.Parts.FirstOrDefault(x => x.Name == partName);
    }
}