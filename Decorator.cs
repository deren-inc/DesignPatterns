using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    interface Component
    {
        void Operation();
    }

    class ConcreteComponent : Component
    {
        public void Operation()
        {
            System.Console.Write("pattern");
        }
    }

    class Decorator : Component
    {
        private Component component;

        public Decorator(Component component)
        {
            this.component = component;
        }

        public void Operation()
        {
            BeforeOperation();
            component.Operation();
            AfterOperation();
        }

        private void BeforeOperation()
        {
            Console.Write("decorator ");
        }

        private void AfterOperation()
        {
            Console.Write(".");
        }
    }

    class DecoratorPattern
    {
        public static void Test()
        {
            ConcreteComponent concreteComponent = new ConcreteComponent();
            Decorator decorator = new Decorator(concreteComponent);
           
            // decorator is also a component so can be also decorated
            Component component = decorator;
            Decorator dec = new Decorator(component);

            decorator.Operation();
            System.Console.WriteLine(string.Empty);
            dec.Operation();
            System.Console.WriteLine(string.Empty);
        }
    }

}
