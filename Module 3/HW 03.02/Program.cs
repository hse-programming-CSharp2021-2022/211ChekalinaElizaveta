using System;
using System.Text;

namespace HW_03._02
{
    public struct Person : IComparable<Person>
    {
        private string name;
        private string lastname;
        private int age;

        public Person(string name, string lastname, int age)
        {
            this.name = name;
            this.lastname = lastname;
            if (age < 0)
            {
                throw new ArgumentException("Возраст должен быть неотрицательным!");
            }

            this.age = age;
        }


        public int CompareTo(Person person)
        {
            if (this.age > person.age)
            {
                return 1;
            }

            if (this.age == person.age)
            {
                return 0;
            }

            return -1;
        }

        public override string ToString()
        {
            return $"Person. Name: {this.name}. Surname: {this.lastname}. Age: {this.age}";
        }
    }
    
    
    class Program
    {
        private static string[] names =
            {"James", "John", "Jane", "Jack", "Jade", "Julia", "Jackson", "Judie", "Joan", "Jil"};

        private static string[] surnames =
            {"Doe", "McKenzie", "Stone", "Gillian", "Brown", "Gatsby", "Fritz", "Rolling", "Bittie", "Jackson"};

        private static Random rnd = new ();
        private static Person GeneratePerson()
        {
            string name = names[rnd.Next(10)];
            string lastname = surnames[rnd.Next(10)];
            int age = rnd.Next(1, 101);
            return new Person(name, lastname, age);
        }
        static void Main()
        {
            int amount;
            int.TryParse(Console.ReadLine(), out amount);
            var persons = new Person[amount];
            Random random = new();
            for (var i = 0; i < amount; i++)
            {
                persons[i] = GeneratePerson();
            }
            Array.ForEach(persons, x => Console.WriteLine(x));
            Console.WriteLine();
            Array.Sort(persons);
            Array.ForEach(persons, x => Console.WriteLine(x));
        }
    }
}