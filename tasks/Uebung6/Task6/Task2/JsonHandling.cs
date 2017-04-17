using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Task6
{
    class JsonHandling
    {
        public static void Run(Animal[] animals)
        {
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };

            var text = JsonConvert.SerializeObject(animals, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            File.WriteAllText(filename, text);

            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<Animal[]>(textFromFile, settings);

            foreach (var x in itemsFromFile) Console.WriteLine($"The {x.Breed} is called {x.Name}. It is {x.Age} years old and sounds like {x.Sound()}");

        }
    }
}
