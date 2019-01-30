using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Command
{
    interface Command
    {
        void Execute();
    }

    class Receiver
    {
        public void Action1(string arg)
        {
            System.Console.WriteLine("Receiver.Action1 " + arg);  
        }
        public void Action2(int arg)
        {
            System.Console.WriteLine("Receiver.Action2 " + arg);
        }
    }

    class ConcreteCommand1 : Command
    {
        private Receiver receiver;
        private string arg;

        public ConcreteCommand1(Receiver receiver, string arg)
        {
            this.receiver = receiver;
            this.arg = arg;
        }

        public void Execute()
        {
            receiver.Action1(arg);
        }
    }

    class ConcreteCommand2 : Command
    {
        private Receiver receiver;
        private int arg;

        public ConcreteCommand2(Receiver receiver, int arg)
        {
            this.receiver = receiver;
            this.arg = arg;
        }

        public void Execute()
        {
            receiver.Action2(arg);
        }
    }

    class Macro : Command
    {
        private List<Command> commands =  new List<Command>();

        public void AddCommand(Command cmd)
        {
            commands.Add(cmd);
        }
        public void Execute()
        {
            foreach (Command c in commands)
            {
                c.Execute();
            }
        }
    }

    class Invoker
    {
        private Command cmd;
        public Invoker(Command cmd)
        {
            this.cmd = cmd;
        }

        public void ExecuteCommand()
        {
            cmd.Execute();
        }
    }

    class CommandPattern
    {
        public static void Test()
        {
            Receiver receiver = new Receiver();
            ConcreteCommand1 cmd1 = new ConcreteCommand1(receiver, "cmd1");
            ConcreteCommand2 cmd2 = new ConcreteCommand2(receiver, 123);

            Macro macro = new Macro();
            macro.AddCommand(cmd1);
            macro.AddCommand(cmd2);

            Invoker invoker = new Invoker(macro);
            invoker.ExecuteCommand();
        }
    }
}
