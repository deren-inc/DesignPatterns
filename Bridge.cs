using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    interface Implementor
    {
        void Implementation();
    }

    class ConcreteImplementorA : Implementor
    {
        public void Implementation()
        {
            System.Console.WriteLine("ConcreteImplementorA.Implementation");
        }
    }

    class ConcreteImplementorB : Implementor
    {
        public void Implementation()
        {
            System.Console.WriteLine("ConcreteImplementorB.Implementation");
        }
    }

    class Abstraction
    {
        protected Implementor implementor;
        public Abstraction(Implementor implementor)
        {
            this.implementor = implementor;
        }

        public virtual void Operation()
        {
            implementor.Implementation();
        }
    }

    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor implementor) : base(implementor)
        {
        }

        public override void Operation()
        {
            implementor.Implementation();
        }
    }

    class BrigdePattern
    {
        public static void Test()
        {
            ConcreteImplementorA implA = new ConcreteImplementorA();
            ConcreteImplementorB implB = new ConcreteImplementorB();
            RefinedAbstraction rabA = new RefinedAbstraction(implA);
            RefinedAbstraction rabB = new RefinedAbstraction(implB);
            rabA.Operation();
            rabB.Operation();
        }
    }
}

