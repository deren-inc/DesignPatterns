using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
    interface Target
    {
        string Operation();
    }

    class Adaptee
    {
        public string Method1()
        {
            return "Adapter";
        }

        public string Method2()
        {
            return "pattern";
        }
    }

    class Adapter : Target
    {
        private Adaptee adaptee;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public string Operation()
        {
            return adaptee.Method1() + " " + adaptee.Method2();
        }
    }

    class AdapterPattern
    {
        private static void f(Target t)
        {
            System.Console.WriteLine(t.Operation());
        }
        public static void Test()
        {
            Adaptee adaptee = new Adaptee(); 
            Adapter adapter = new Adapter(adaptee);
            f(adapter);
        }
    }
}
