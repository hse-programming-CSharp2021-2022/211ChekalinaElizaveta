using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
namespace Task01
{
    abstract class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            protected set { this.name = value; }
        }
        public string
            Pocket
        {
            get;
            set;
        }
        public abstract void Receive(string present);
        public Person(string name)
        {
            this.name = name; Pocket = string.Empty;
        }
        public override string ToString() { return Name + " " + Pocket; }
    }
    class SnowMaiden : Person
    {
        static Random random = new Random();
        private string CreateGift()
        {
            string s = "";
            for (int i = 0; i <= 2; i++)
                s += ((char)(random.Next('a', 'z' + 1))).ToString();
            s += s[1];
            s += s[0];
            return s;
        }
        public string[] CreatePresents(int amount)
        {
            string[] gifts = new string[amount];
            for (int i = 0; i < gifts.Length; i++)
                gifts[i] = CreateGift();
            return gifts;
        }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else throw new ArgumentException();
        }
        public SnowMaiden(string name) : base(name) { }
    }
    class Santa : Person
    {
        List<string> sack;
        static Random random = new Random();
        public void Request(SnowMaiden snowMaiden, int amount)
        {
            string[] gifts = snowMaiden.CreatePresents(amount);
            sack.AddRange(gifts);
        }
        public Santa(string name) : base(name)
        {
            sack = new List<string>();
        }
        public void Give(Person person)
        {
            if (sack.Count > 0)
            {
                int n = random.Next(0, sack.Count);
                person.Receive(sack[n]);
                sack.RemoveAt(n);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else throw new ArgumentException();
        }
    }
    class Child : Person
    {
        public string additionalPocket
        {
            get; set;
        }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else if (additionalPocket.Equals(string.Empty))
                additionalPocket = present;
            else throw new ArgumentException();
        }
        public Child(string name) : base(name)
        {
            additionalPocket = string.Empty;
        }
        public override string ToString()
        {
            return Name + " " + Pocket + " " + additionalPocket;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit;
            do
            {
                Santa santa = new Santa("Santa");
                SnowMaiden snowMaiden = new SnowMaiden("SnowMaiden");
                Random random = new Random();
                List<Person> people = new List<Person>();
                people.Add(santa);
                people.Add(snowMaiden);
                int n = 10;
                for (int i = 2; i < 2 + n; i++)
                {
                    people.Add(new Child("Child" + (i - 2).ToString()));
                }
                santa.Request(snowMaiden, random.Next(1, 5));
                bool snowMaidenGiven = false;
                int j = 0;
                while (people.Count > 1)
                {
                    int prob = random.Next(0, 101);
                    if (prob > 10)
                    {
                        int k = random.Next(1, people.Count);
                        try
                        {
                            santa.Give(people[k]);
                            if (people[k] is SnowMaiden)
                            {
                                snowMaidenGiven = true;
                            }
                            Console.WriteLine($"Given {j} to {people[k]}");
                            j++;

                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine($"Removed: {people[k]} >:(");
                            people.RemoveAt(k);
                          

                        } catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Out of gifts :(");
                            break;
                        }
                    }
                    else
                        try
                        {
                            santa.Give(people[0]);
                            Console.WriteLine($"Given {j} to {santa}");
                            j++;
                        } catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Out of gifts :(");
                            break;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("Removing Santa :(");
                            break;
                        }
                        
                    if (!snowMaidenGiven)
                    {
                        santa.Request(snowMaiden, random.Next(1, 5));
                    }
                }
                if (people.Count == 1 && people[0] is Santa)
                {
                    Console.WriteLine("Only Santa left :)");
                }
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для повтора решения.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}