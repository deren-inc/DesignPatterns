using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Visitor
{
    interface Visitor
    {
        void VisitConcreteElementA(ConcreteElementA visitable);
        void VisitConcreteElementB(ConcreteElementB visitable);
    }

    class ConcreteVisitor : Visitor
    {
        public void VisitConcreteElementA(ConcreteElementA visitable)
        {
            System.Console.WriteLine("ConcreteVisitor perform opetation on ConcreteElementA");
        }

        public void VisitConcreteElementB(ConcreteElementB visitable)
        {
            System.Console.WriteLine("ConcreteVisitor perform operation on ConcreteElementB");
        }
    }

    interface Visitable
    {
        void Accept(Visitor visitor);
    }


    class ConcreteElementA : Visitable
    {
        public void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
    }

    class ConcreteElementB : Visitable
    {
        public void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
    }

    class ObjectStructure : Visitable
    {
        private HashSet<Visitable> elements = new HashSet<Visitable>();

        public void AddElement(Visitable element)
        {
            elements.Add(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach(Visitable element in elements)
            {
                element.Accept(visitor);
            }
        }
    }
    
    class VisitorPattern
    {
        public static void Test()
        {
            ConcreteVisitor visitor = new ConcreteVisitor();
            ConcreteElementA elementA = new ConcreteElementA();
            ConcreteElementB elementB = new ConcreteElementB();
            ObjectStructure objectStructure = new ObjectStructure();

            objectStructure.AddElement(elementA);
            objectStructure.AddElement(elementB);
            objectStructure.Accept(visitor);
        }
    }

}
