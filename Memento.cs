using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Memento
{
    class Memento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }

        public void SetState(string state)
        {
            this.state = state;
        }
    }

    class Orginator
    {
        private string state;
        public Orginator(string state)
        {
            this.state = state;
        }
        public Memento CreateMemento()
        {
            return new Memento(state);
        }

        public void SetMemento(Memento memento)
        {
            state = memento.GetState();
        }
    }

    class MementoPattern
    {
        public static void Test()
        {
            Orginator orginator = new Orginator("State");
            Memento memento = new Memento("Memento Design Pattern");
            orginator.SetMemento(memento);
            memento = orginator.CreateMemento();
            System.Console.WriteLine(memento.GetState());
        }
    }
}
