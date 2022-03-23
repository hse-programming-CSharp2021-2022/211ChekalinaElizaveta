using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace HW_18._02
{
    /*
    В программе описать классы:
    •Human (имя);
    •Professor (наследник Human);
    •Department  (название, композиционно включает список сотрудников – объекты типа Human);
    •University (название, агрегационно включает список департаментов).
    •
    Задать массив университетов. Сериализовать и десериализовать бинарной/xml/json.
    */
    [Serializable]
    public class Human
    {
        public string Name { get; set; }

        public Human()
        {
        }
    }

    [Serializable]
    class Professor : Human
    {
        public Professor()
        {
        }
    }

    [Serializable]
    public class Department
    {
        private static Random rnd = new();

        private static string[] names =
        {
            "James", "John", "Jane", "Jack", "Jade", "Julia", "Jackson", "Judie", "Joan", "Jill", "Adam", "Celeste",
            "Robin", "Brook", "Kevin", "Jason", "Peach", "Kitty", "Larson", "Larry", "Olivia", "Artie", "Nora", "Ruth",
            "Maggie", "Maria", "Nigel", "Miriam", "Marianne", "Margaret", "Marge", "Dylan", "Daniel", "Jared", "Yuna",
            "Eric", "Erica", "Candice", "Paul", "Robert", "Eddie", "Bernard", "Jacobson", "Carson", "William", "Walter",
            "Rafe", "Nick", "George", "Roman", "Molly", "Polly", "Dolly", "Terry", "Melody", "Jean"
        };

        public List<Human> Humans { get; set; }

        public Department()
        {
            int numOfHumans = rnd.Next(1, 5);
            List<Human> humans = new List<Human>();
            for (int i = 0; i < numOfHumans; i++)
            {
                var human = new Human();
                humans.Add(human);
                human.Name = names[rnd.Next(names.Length)];
            }

            this.Humans = humans;
        }

        public override string ToString()
        {
            string ans = "Department: ";
            foreach (var human in Humans)
            {
                ans += $"{human.Name}, ";
            }

            return ans[..^2];
        }
    }

    [Serializable]
    public class University
    {
        public List<Department> Departments { get; set; }

        public University()
        {
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder("University:");
            foreach (var department in this.Departments)
            {
                sb.Append($"\n{department}");
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<University> universities = new List<University>();

            for (int i = 0; i < 3; i++)
            {
                List<Department> departments = new List<Department>();
                for (int j = 0; j < 2; j++)
                {
                    departments.Add(new Department());
                }

                var uni = new University();
                uni.Departments = departments;
                universities.Add(uni);
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("binary.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, universities);
            }

            using (FileStream file = new FileStream("fs.txt", FileMode.OpenOrCreate))
            {
                List<University> unies = (List<University>) formatter.Deserialize(file);
                Console.WriteLine();
                foreach (var uni in unies)
                {
                    Console.WriteLine(uni);
                }

                Console.WriteLine();
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<University>));
            using (FileStream fs = new FileStream("xml.txt", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, universities);
            }

            using (FileStream file = new FileStream("xml.txt", FileMode.Open))
            {
                var unies = (List<University>) xmlSerializer.Deserialize(file);
                Console.WriteLine();
                foreach (var uni in unies)
                {
                    Console.WriteLine(uni);
                }

                Console.WriteLine();
            }

            using (StreamWriter streamWriter = new StreamWriter("json.txt", false))
            {
                var jsonUni = JsonSerializer.Serialize(universities);
                streamWriter.Write(jsonUni);
            }
            
            using (StreamReader sr = new StreamReader("json.txt"))
            {
               
                var unies = JsonSerializer.Deserialize<List<University>>(sr.ReadToEnd());
                Console.WriteLine();
                foreach (var uni in unies)
                {
                    Console.WriteLine(uni);
                }

                Console.WriteLine();
            }
        }
    }
}