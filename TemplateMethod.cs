using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.TemplateMethod
{
    abstract class ApplicationFramework
    {
        public abstract void Step1();
        public abstract void Step2();

        public void TemplateMethod()
        {
            Step1();
            Step2();
        }
    }

    class Application : ApplicationFramework
    {
        public override void Step1()
        {
            System.Console.WriteLine("Template method");
        }

        public override void Step2()
        {
            System.Console.WriteLine("design pattern");
        }
    }

    class TemplateMethodPattern
    {
        public static void Test()
        {
            Application app = new Application();
            app.TemplateMethod();
        }
    }
}
