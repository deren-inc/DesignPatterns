using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Flyweight
{
    class Flyweight
    {
        private string state;
        public Flyweight(string state)
        {
            this.state = state;
        }

        public string DoSomething(string s)
        {
            return s + " " + state;
        }
    }

    class FlyweightFactory
    {
        private Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

        private bool FlyweightExist(string key)
        {
            return flyweights.ContainsKey(key);
        }

        public Flyweight GetFlyweight(string key)
        {
            if (!FlyweightExist(key))
                flyweights.Add(key, new Flyweight(key));

            return flyweights[key];
        }

        public int GetFlyweightsNumber()
        {
            return flyweights.Count;
        }
    }

    class FlyweightPattern
    {
        public static void Test()
        {
            HashSet<string> colors = new HashSet<string> { "red", "green", "blue" };
            HashSet<string> shades = new HashSet<string> { "pale", "dark", "light" };

            FlyweightFactory factory = new FlyweightFactory();

            foreach (string s in shades)
            {
                foreach (string c in colors)
                {
                    Flyweight flyweight = factory.GetFlyweight(c);
                    System.Console.WriteLine(flyweight.DoSomething(s));
                }
            }

            System.Console.WriteLine("Number of Flyweights: " + factory.GetFlyweightsNumber());
        }
    }
}
