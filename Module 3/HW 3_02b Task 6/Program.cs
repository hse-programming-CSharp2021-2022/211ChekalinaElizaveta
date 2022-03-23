using System;

namespace HW_3_02b_Task_6
{
    public abstract class Creature
    {
        public string Location;

        public virtual void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            
        }
    }

    public class RingIsFoundEventArgs : EventArgs
    {
        public RingIsFoundEventArgs(string s)
        {
            Message = s;
        }

        public String Message { get;}
    }

    public class Wizard : Creature
    {
        public string Name { get; set; }

        public delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs a);

        public event RingIsFoundEventHandler RaiseRingIsFoundEvent;

        public Wizard(string s)
        {
            this.Name = s;
        }

        public Wizard()
        {
            
        }

        public void RingIsFound()
        {
            Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл! ");
            RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs("Ривендейл"));
            this.Location = "Ривендейл";
        }
    }

    public class Hobbit: Creature
    {
        public string Name { get;set; }

        public Hobbit(string s)
        {
            this.Name = s;
        }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Покидаю Шир! Иду в " + e.Message);
            this.Location = e.Message;
        }
    }

    public class Human: Creature
    {
        public string Name { get; set; }

        public Human(string s)
        {
            Name = s;
        }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Волшебник {((Wizard) sender).Name} позвал. Моя цель {e.Message}");
            this.Location = e.Message;
        }
    }

    public class Elf: Creature
    {
        public string Name { get; set; }

        public Elf(string s)
        {
            this.Name = s;
        }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine(
                $"{Name} >> Звёзды светят не так ярко как обычно. Цветы увядают. Листья предсказывают идти в " +
                e.Message);
            this.Location = e.Message;
        }
    }

    public class Dwarf: Creature
    {
        public string Name { get; set; }

        public Dwarf(string s)
        {
            this.Name = s;
        }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Точим топоры, собираем припасы! Выдвигаемся в " + e.Message);
            this.Location = e.Message;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Гендальф");
            Creature[] creatures = new Creature[8];
            for (int i = 0; i < 4; i++)
            {
                creatures[i] = new Hobbit($"Хоббит {i}");
                
            }

            creatures[4] = new Human("Боромир");
            creatures[5] = new Human("Арагорн");
            Dwarf dwarf = new Dwarf("Гимли");
            creatures[6] = dwarf;
            Elf elf = new Elf("Леголас");
            creatures[7] = elf;
            foreach (var creature in creatures)
            {
                 wizard.RaiseRingIsFoundEvent += creature.RingIsFoundEventHandler;
            }
            wizard.RingIsFound();
        }
    }
}