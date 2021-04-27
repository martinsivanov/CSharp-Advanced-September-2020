using System;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] memberInfo = Console.ReadLine().Split().ToArray();

                string memberName = memberInfo[0];
                int memberAge = int.Parse(memberInfo[1]);

                Person person = new Person(memberName, memberAge);

                family.AddMember(person);


            }
            var result = family.GetMemberAbove30();

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
