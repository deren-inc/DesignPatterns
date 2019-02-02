using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Model of Publisher-Subscriber
 */

namespace Patterns.Observer
{
    interface Observer
    {
        void Update(Subject subject);
    }

    class Subject
    {
        private string state;
        private HashSet<Observer> observers = new HashSet<Observer>();

        public void AttachObserver(Observer o)
        {
            observers.Add(o);
        }

        public void DetachObserver(Observer o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (Observer o in observers)
                o.Update(this);
        }

        public void ChangeState(string state)
        {
            this.state = state;
            NotifyObservers();
        }

        public string GetState()
        {
            return state;
        }
     }

    class ObserverImplementation : Observer
    {
        private string state = string.Empty;
        public void Update(Subject subject)
        {
            state = subject.GetState();
        }
        public string getState()
        {
            return state;
        }
    }

    class ObserverPattern
    {
        public static void Test()
        {
            ObserverImplementation observer1 = new ObserverImplementation();
            ObserverImplementation observer2 = new ObserverImplementation();
            ObserverImplementation observer3 = new ObserverImplementation();

            Subject subject = new Subject();
            subject.AttachObserver(observer1);
            subject.AttachObserver(observer2);
            subject.AttachObserver(observer3);

            subject.ChangeState("update state");

            System.Console.WriteLine(observer1.getState());
            System.Console.WriteLine(observer2.getState());
            System.Console.WriteLine(observer3.getState());

        }
    }
}
