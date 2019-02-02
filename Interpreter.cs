using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Interpreter
{
    class Context
    {
        private string input;
        private string output;

        public Context(string input)
        {
            this.input = input;
        }

        public void SetInput(string input)
        {
            this.input = input;
        }

        public void SetOutput(string output)
        {
            this.output = output;
        }

        public string GetInput()
        {
            return input;
        }

        public string GetOutput()
        {
            return output;
        }
    }

    abstract class AbstractExpresion
    {
        public void Interpret(Context context)
        {
            string output = context.GetInput().Replace(Search(), Replace());
            context.SetInput(output);
            context.SetOutput(output);
        }

        public abstract string Replace();

        public abstract string Search();    
    }

    class ExpressionA : AbstractExpresion
    {
        public override string Search()
        {
            return "A";
        }

        public override string Replace()
        {
            return "AA";
        }
    }

    class ExpressionB : AbstractExpresion
    {
        public override string Search()
        {
            return "B";
        }

        public override string Replace()
        {
            return "BB";
        }
    }

    class InterpreterPattern
    {
        public static void Test()
        {
            Context context = new Context("A*B+C");
            ExpressionA ea = new ExpressionA();
            ExpressionB eb = new ExpressionB();

            List<AbstractExpresion> expressions = new List<AbstractExpresion> { ea, eb };

            foreach (AbstractExpresion e in expressions)
                e.Interpret(context);

            System.Console.WriteLine(context.GetOutput());
        }
    }
}
