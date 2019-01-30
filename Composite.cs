using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Composite
{
    interface Component
    {
        void Print();
    }

    class Composite : Component
    {
        private string name;
        private List<Component> elements;

        public Composite(string name)
        {
            this.name = name;
            elements = new List<Component>();
        }

        public void AddCompoment(Component component)
        {
            elements.Add(component);
        }

        public void RemoveComponent(Component element)
        {
            elements.Remove(element);
        }

        public Component GetChild(int index)
        {
            return elements.ElementAt(index);
        }

        public void Print()
        {
            System.Console.WriteLine(name);

            foreach (Component e in elements)
            {
                e.Print();
            }
        }
    }

    class Leaf : Component
    {
        private string name;
        public Leaf(string name)
        {
            this.name = name;
        }

        public void Print()
        {
            System.Console.WriteLine(name);
        }
    }

    class CompositePattern
    {
        private static void PrintComponent(Component c)
        {
            c.Print();
        }

        public static void Test()
        {
            // unix directory structure
            Composite root  = new Composite("/");
            Composite usr = new Composite("usr");
            Composite home = new Composite("home");
            Composite dev = new Composite("dev");
            Composite user = new Composite("user");
            Leaf file = new Leaf("file.txt");

            user.AddCompoment(file);
            home.AddCompoment(user);
            root.AddCompoment(usr);
            root.AddCompoment(dev);
            root.AddCompoment(home);

            // composition of objects and object are treating in the same way 
            PrintComponent(root);
            //PrintComponent(file);

        }
    }
}
