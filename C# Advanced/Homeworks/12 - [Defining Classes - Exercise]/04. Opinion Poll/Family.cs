using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }


        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people.OrderByDescending(p => p.Age).FirstOrDefault();
        }
        public List<Person> GetMemberAbove30()
        {
            var family = this.people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
            return family;
        }
        
    }

}
