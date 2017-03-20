using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void newDog()
        {
            var a = new Dog("Scotty", "Mix", 9);
            Assert.IsTrue(a.Name == "Scotty");
            Assert.IsTrue(a.Breed == "Mix");
            Assert.IsTrue(a.Age == 9);
        }

        [Test]
        public void newSnake()
        {
            var b = new Snake("Grimpi", "Natter", 5);
            Assert.IsTrue(b.Name == "Grimpi");
            Assert.IsTrue(b.Breed == "Natter");
            Assert.IsTrue(b.Age == 5);
        }

        [Test]
        public void DogNegativAge()
        {
            Assert.Catch(() =>
            {
                var z = new Dog("Jamie", "Beagle", -3);
            });
        }

        [Test]
        public void SnakeNegaiveAge()
        {
            Assert.Catch(() =>
            {
                var x = new Snake("Sammi", "King Viper", -5);
            });
        }

        [Test]
        public void DogBirthday()
        {
            var c = new Dog("Niki", "Pudel", 5);
            Assert.IsTrue(c.Age == 5);
            c.Birthday();
            Assert.IsTrue(c.Age == 6);
        }

        [Test]
        public void SnakeSound()
        {
            var d = new Snake("Laila", "Viper", 10);
            Assert.IsTrue(d.Sound() == "Ssssssssssss, Ssssssssss");
        }

        [Test]
        public void DogSoun()
        {
            var e = new Dog("Sissi", "Neufundlaender", 2);
            Assert.IsTrue(e.Sound() == "Waff, waff, waff");
        }

        [Test]
        public void DogNoName()
        {
            Assert.Catch(() =>
            {
                var f = new Dog("", "Labrador", 3);
            });
        }

        [Test]
        public void SnakeNoName()
        {
            Assert.Catch(() =>
            {
                var g = new Snake("", "Natter", 1);
            });
        }

        [Test]
        public void DogNoBreed()
        {
            Assert.Catch(() =>
            {
                var h = new Dog("Zoe", "", 1);
            });
        }

        [Test]
        public void SnakeNoBreed()
        {
            Assert.Catch(() =>
            {
                var i = new Snake("Sanndy", "", 1);
            });
        }
    }
}
