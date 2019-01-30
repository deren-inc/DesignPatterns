using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Mediator
{
    interface Mediator
    {
        void Send(string id, string message);
    }

    class Colleague
    {
        private Mediator mediator;
        private string id;

        public Colleague(string id)
        {
            this.id = id;
        }

        public string GetId()
        {
            return id;
        }

        public void RegisterMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public void Receive(string msg)
        {
            System.Console.WriteLine("Message received by " + id + ": " + msg);
        }

        public void Send(string ids, string msg)
        {
            System.Console.WriteLine(id + " send message to " + ids + " : " + msg);
            mediator.Send(ids, msg);
        }
    }

    class ConcreteMediator : Mediator
    {
        private Dictionary<string, Colleague> colleagues = new Dictionary<string, Colleague>();

        private bool IsRegistered(string id)
        {
            return colleagues.ContainsKey(id);
        }

        public void Send(string id, string message)
        {
            if (IsRegistered(id))
            {
                Colleague c = colleagues[id];
                c.Receive(message);
            }
        }

        public void RegisterColleague(Colleague colleague)
        {
            if (!IsRegistered(colleague.GetId()))
            {
                colleague.RegisterMediator(this);
                colleagues.Add(colleague.GetId(), colleague);
            }
        }
    }

    class MediatorPattern
    {
        public static void Test()
        {
            Colleague peter = new Colleague("Peter");
            Colleague paul = new Colleague("Paul");
            Colleague kate = new Colleague("Kate");

            ConcreteMediator mediator = new ConcreteMediator();
            mediator.RegisterColleague(peter);
            mediator.RegisterColleague(paul);
            mediator.RegisterColleague(kate);

            peter.Send("Paul", "WU");  //whats up?
            paul.Send("Peter", "aas"); //alive and smiling
            kate.Send("Paul", "diku"); //do I know you?
            paul.Send("Kate", "ydkm"); //you don't know me
        }
    }
}
