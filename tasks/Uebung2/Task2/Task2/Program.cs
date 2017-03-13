using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Dog
    {
        private string name;
        private string breed;
        private int age;

        /*Constructor*/
        public Dog(string newname, string newbreed, int newage)
        {
            Name = newname;
            Breed = newbreed;
            Age = newage;
        }

        public int Age {
            get
            {
                return age;
            }
            set
            {
                if (value < 0) throw new Exception("Age is negative");
                age = value;
            }
        }

        public string Name {
            get {
                return name;
            }
            set {
                if (value == null || value.Length == 0) throw new Exception("no Name");
                name = value;
            }
        
        }
        
        public string Breed
        {
            get
            {
                return breed;
            }
            set
            {
                if (value == null || value.Length == 0) throw new Exception("no breed");
                breed = value;
            }
        }

        public void Birthday()
        {
            Age = Age + 1;
            Console.WriteLine($"It is {Name} Birthday! The new age is {Age}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dog Doggy = new Dog("Zoe", "Pudel", -3);
                Console.WriteLine($"The Dogs name is {Doggy.Name}\n");
                Console.WriteLine($"The Dogs breed is {Doggy.Breed}\n");
                Console.WriteLine($"The Dogs age is {Doggy.Age}\n");
                Doggy.Birthday();
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler! "+ e.Message);
                return;
            }
        }
    }
}
