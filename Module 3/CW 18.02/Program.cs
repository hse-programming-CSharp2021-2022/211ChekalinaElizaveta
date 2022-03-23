using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace CW_18._02
{
    [Serializable]
    public class Student
    {
        public string Surname;
        public int Year;

        public Student()
        {
            Surname = null;
            Year = 0;
        }

        public Student(string Surname, int year)
        {
            this.Surname = Surname;
            this.Year = year;
        }
    }

    [Serializable]
    public class Group
    {
        public List<Student> Students { get; private set; }

        public Group()
        {
            this.Students = new List<Student>();
        }
    }

    class Program
    {
        public static void Main()
        {
            Group group1 = new Group();
            group1.Students.Add(new Student("Shulepa", 1));
            group1.Students.Add(new Student("Chekalina", 1));
            group1.Students.Add(new Student("Golomedov", 1));
            Group group2 = new Group();
            group2.Students.Add(new Student("Valilyev", 1));
            group2.Students.Add(new Student("Mamedli", 1));
            group2.Students.Add(new Student("Shmayhel", 1));
            // binary
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("binary.txt", FileMode.Create))
            {
                formatter.Serialize(fs, group1);
            }

            using (FileStream fs = new FileStream("binary.txt", FileMode.Open))
            {
                Group group = (Group) formatter.Deserialize(fs);
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"Student {student.Surname}. Year {student.Year}");
                }
            }

            Console.WriteLine();
            XmlSerializer serializer = new XmlSerializer(typeof(Group));
            using (FileStream fs = new FileStream("xml.txt", FileMode.Create))
            {
                serializer.Serialize(fs, group1);
            }

            using (FileStream fs = new FileStream("xml.txt", FileMode.Open))
            {
                Group group = (Group) serializer.Deserialize(fs);
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"Student {student.Surname}. Year {student.Year}");
                }
            }

            Console.WriteLine();
            using (StreamWriter fs = new StreamWriter("json.txt"))
            {
                fs.Write(JsonSerializer.Serialize(group1));
            }

            using (StreamReader stream1 = new StreamReader("json.txt"))
            {
                Group group = JsonSerializer.Deserialize<Group>(stream1.ReadToEnd());
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"Student {student.Surname}. Year {student.Year}");
                }
            }
        }
    }
}