using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy
{
    interface Strategy
    {
        void Execute();
    }

    class Strategy1 : Strategy
    {
        public void Execute()
        {
            Console.WriteLine("Exexuting Strategy 1 ...");
        }
    }

    class Strategy2 : Strategy
    {
        public void Execute()
        {
            Console.WriteLine("Exexuting Strategy 2 ...");
        }
    }
    class Context
    {
        private Strategy strategy;
        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            strategy.Execute();
        }
    }

    class StrategyPattern
    {
        public static void Test()
        {
            Strategy1 strategy1 = new Strategy1();
            Strategy2 strategy2 = new Strategy2();
            Context context = new Context(strategy1);
            context.ExecuteStrategy();
            context.SetStrategy(strategy2);
            context.ExecuteStrategy();
        }
    }
}
