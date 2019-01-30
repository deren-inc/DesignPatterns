using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Patterns.Singleton
{
    public class Singleton
    {
        private static Singleton instance = null;
        private Singleton()  
        {}
        public static Singleton GetInstance()
        {
            if (instance == null)
                instance = new Singleton();
            
            return instance;
        }
        public void method()
        {
            Console.WriteLine("Singletons method");
        }
    }


    class SingetonPattern
    {
        public static void Test()
        {
            Singleton singleton = Singleton.GetInstance();
            singleton.method();
        }
    }
}
