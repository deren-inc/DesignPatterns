using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Builder
{
    class Product
    {
        private string parts = string.Empty;
        public Product()
        {}

        public void AddPart(string part)
        {
            parts += part + "\n";
        }

        public string GetParts()
        {
            return parts;
        }
    }

    interface Builder
    {
        void BuildPart1();
        void BuildPart2();
    }

    class ConcreteBuilder1 : Builder
    {
        private Product product = new Product();

        public void BuildPart1()
        {
            product.AddPart("Builder");
        }

        public void BuildPart2()
        {
            product.AddPart("pattern");
        }

        public Product GetProduct()
        {
            return product;
        }
    }

    class ConcreteBuilder2 : Builder
    {
        private Product product = new Product();

        public void BuildPart1()
        {
            product.AddPart("Pattern");
        }

        public void BuildPart2()
        {
            product.AddPart("builder");
        }

        public Product GetProduct()
        {
            return product;
        }
    }

    class Director
    {
        private Builder builder;

        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildPart1();
            builder.BuildPart2();
        }
    }

    class BuilderPattern
    {
        public static void Test()
        {
            ConcreteBuilder1 concreteBuilder1 = new ConcreteBuilder1();
            ConcreteBuilder2 concreteBuilder2 = new ConcreteBuilder2();

            Director director1 = new Director(concreteBuilder1);
            Director director2 = new Director(concreteBuilder2);

            director1.Construct();
            director2.Construct();

            Product product = concreteBuilder1.GetProduct();
            System.Console.WriteLine(product.GetParts());

            product = concreteBuilder2.GetProduct();
            System.Console.WriteLine(product.GetParts());
        }
    }
}
