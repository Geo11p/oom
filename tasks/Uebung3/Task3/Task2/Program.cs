using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var animals = new Animal[]
                {
                    new Dog("Zoe", "Pudel", 3),
                    new Dog("Lucky", "Pug", 8),
                    new Snake("Carla","King Cobra", 2),
                    new Snake("Elvira", "Phyton",4),
                };

                foreach (var x in animals)
                {
                    Console.WriteLine($"The {x.Breed} is called {x.Name}. It is {x.Age} years old and sounds like {x.Sound()}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler! " + e.Message);
                return;
            }
        }
    }

    interface Animal
    {
        string Name
        {
            set;
            get;
        }

        string Breed
        {
            set;
            get;
        }

        int Age
        {
            set;
            get;
        }

        string Sound();
    }

    class Dog : Animal
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

        public string Sound()
        {
           return "Waff, waff, waff";
        }
    }

    class Snake : Animal
    {
        private string name;
        private string breed;
        private int age;

        public Snake(string newname, string newbreed, int newage)
        {
            Name = newname;
            Breed = newbreed;
            Age = newage;
        }

        public int Age
        {
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

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
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

        public string Sound()
        {
            return "Ssssssssssss, Ssssssssss";
        }
    }
}
