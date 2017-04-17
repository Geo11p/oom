using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Reactive.Linq;
using System.Reactive.Subjects;


namespace Task6
{

    public class Program
    {
        static void Main(string[] args)
        {

            //SerializeTask();
            //PushTask();
            TaskTask();
            
        }

        static void SerializeTask()
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

                foreach (var x in animals) Console.WriteLine($"The {x.Breed} is called {x.Name}. It is {x.Age} years old and sounds like {x.Sound()}");
                JsonHandling.Run(animals);
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler! " + e.Message);
                return;
            }
            Console.ReadLine();
        }

        static void PushTask()
        {
            var source = new Subject<Dog>();

            //source
            // .Sample(TimeSpan.FromSeconds(2.0))
            // .Subscribe(x => Console.WriteLine($"read {x}"));

            source
              .Where(x => x.Age > 5)
              .Subscribe(x => Console.WriteLine($"received {x.Name} {x.Breed} {x.Age}"))
              ;

            var t = new Thread(() =>
            {
                Random r = new Random();
                while (true)
                {
                    string name = RandomString(3, r);
                    string breed = RandomString(5, r);
                    int age = r.Next(10);

                    Dog d = new Dog(name, breed, age);
                    Console.WriteLine($"The {d.Breed} is called {d.Name}. It is {d.Age} years old and sounds like {d.Sound()}");
                    // Console.WriteLine($"added {d}\n");
                    source.OnNext(d);
                    Thread.Sleep(500);
                }
            });
            t.Start();
        }

        static void TaskTask()
        {

            Task task1 = Calculate_volume();
            task1.ContinueWith(t => Console.WriteLine("Calculation of Dog vs. Human age finished"));
            task1.ContinueWith(t => Console.WriteLine("Tasks finished"));

            Console.WriteLine("\n Something happens while calculating the age\n");
            Thread.Sleep(2000);
            Console.WriteLine("\n There are still things happening\n");
            Thread.Sleep(2000);
            Console.WriteLine("\n things finished \n");

            task1.ContinueWith(t => Console.WriteLine("Everything finished"));

        }

        public static string RandomString(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static async Task Calculate_volume()
        {
            for (int i = 1; i<=15; i++)
            {
                int ret = await SlowCalculationOfHumanAge(i);
                Console.WriteLine($"Dog Age: {i}\n Human Age: {ret}\n\n");
            }
        }

        static Task<int> SlowCalculationOfHumanAge(int DogAge)
        {
            return Task.Run(() =>
            {
                int ret = 1 + ((DogAge - 1) * 7);
                Thread.Sleep(250);
                return ret;
            });
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
        [JsonConstructor]
        public Dog(string name, string breed, int age)
        {
            Name = name;
            Breed = breed;
            Age = age;
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

        [JsonConstructor]
        public Snake(string name, string breed, int age)
        {
            Name = name;
            Breed = breed;
            Age = age;
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

