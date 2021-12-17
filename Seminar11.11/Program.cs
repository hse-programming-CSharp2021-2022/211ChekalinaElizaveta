using System;
namespace Task01
{
    abstract class Animal
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        abstract public string AnimalSound();
        abstract public string AnimalInfo();
        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public override string ToString()
        {
            return $"Animal Name: {Name}, Age: {Age}, Sound: {AnimalSound()}";
        }
    }
    class Dog : Animal
    {
        public Dog(string name, int age, string kind, bool isTrained) : base(name, age) {
            this.Kind = kind;
            this.IsTrained = isTrained; 
        }
        public string Kind { get; set; }
        public bool IsTrained { get; set; }
        public override string AnimalSound()
        {
            return "Bow wow";
        }
        public override string AnimalInfo()
        {
            return this.ToString() + $", Kind: {Kind}, is trained: {this.IsTrained}";
        }
    }
    class Cow : Animal
    {
        public Cow(string name, int age, int amnt) : base(name, age) {
            this.AmntMilk = amnt; }
        public int AmntMilk { get; set; }
        public override string AnimalSound()
        {
            return "Му";
        }
        public override string AnimalInfo()
        {
            return this.ToString() + $", gives milk: {this.AmntMilk}";
        }
    }
    // код работает, просто закомменчен мэйн
    /*class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo keyToExit;
            do
            {
            Dog dog = new Dog("Mark", 5, "Retriever", true);
            Cow cowow = new Cow("Daisy", 4, 50);
            Console.WriteLine(dog.AnimalInfo());
            Console.WriteLine(cowow.AnimalInfo());
            Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для повтора решения.");
            keyToExit = Console.ReadKey();
        } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }*/
}