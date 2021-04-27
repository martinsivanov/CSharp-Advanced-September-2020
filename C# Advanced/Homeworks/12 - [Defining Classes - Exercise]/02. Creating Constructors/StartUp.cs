using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person person2 = new Person(50);
            Person person3 = new Person("Ivan", 100);
            ;
        }
    }
}
