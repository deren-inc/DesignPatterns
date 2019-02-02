using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Provides easy to use high level interface to a set of interfaces in a subsystem.
 */ 

namespace Patterns.Facade
{
    class Subsystem1
    {
        public void Method1()
        {
            System.Console.WriteLine("Subsystem1.Method1");
        }
    }

    class SubsystemB
    {
        public void MethodC()
        {
            System.Console.WriteLine("SubsystemB.MethodC");
        }
    }

    class Subsystem3
    {
        public string Method2()
        {
            return "Subsystem3.Method2";
        }
    }

    class Facade
    {
        private Subsystem1 subsystem1 = new Subsystem1();
        private Subsystem3 subsystem3 = null;

        public Facade()
        {
            subsystem3 = new Subsystem3();
        }

        public void EasyToUseMethod1()
        {
            subsystem1.Method1();
            System.Console.WriteLine(subsystem3.Method2());
        }

        public void EasyToUseMethod2()
        {
            SubsystemB subsystemB = new SubsystemB();
            subsystemB.MethodC();
            subsystem1.Method1();
        }
    }

    class FacadePattern
    {
        public static void Test()
        {
            Facade facade = new Facade();
            facade.EasyToUseMethod1();
            facade.EasyToUseMethod2();
        }
    }

   
}
