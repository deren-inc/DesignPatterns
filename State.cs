using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.State
{
    class Context
    {
        interface State
        {
            void Handle();
        }

        class ConcreteState1 : State
        {
            public void Handle()
            {
                System.Console.WriteLine("Concrete State 1");
            }
        }

        class ConcreteState2 : State
        {
            public void Handle()
            {
                System.Console.WriteLine("Concrete State 2");
            }
        }

        private State state;

        public Context()
        {
            state = new ConcreteState1();
        }

        public void Request()
        {
            state.Handle();
        }

        public void ChangeStateOperation()
        {
            state = new ConcreteState2();
        }
    }
    
    class StatePattern
    {
        public static void Test()
        {
            Context ctx = new Context();
            ctx.Request();
            ctx.ChangeStateOperation();
            ctx.Request();
        }
    }
}
