using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.AbstractFactory
{
    enum ProductAType
    {
        TYPE1,
        TYPE2
    }

    interface AbstractProductA
    {
        string Method1();
    }

    class ProductAF1T1 : AbstractProductA
    {
        public string Method1()
        {
            return "ProductAF1T1.Method1";
        }
    }

    class ProductAF1T2 : AbstractProductA
    {
        public string Method1()
        {
            return "ProductAF1T2.Method1";
        }
    }

    class ProductAF2T1 : AbstractProductA
    {
        public string Method1()
        {
            return "ProductAF2T1.Method1";
        }
    }

    class ProductAF2T2 : AbstractProductA
    {
        public string Method1()
        {
            return "ProductAF2T2.Method1";
        }
    }

    interface AbstractProductB
    {
        string Method2();
    }

    class ProductBF1 : AbstractProductB
    {
        public string Method2()
        {
            return "ProductBF1.Method2";
        }
    }

    class ProductBF2 : AbstractProductB
    {
        public string Method2()
        {
            return "ProductBF2.Method2";
        }
    }

    interface AbstractFactory
    {
        AbstractProductA CreateProductA(ProductAType type);
        AbstractProductB CreateProductB();
    }

    class ConreteFactory1 : AbstractFactory
    {
        public AbstractProductA CreateProductA(ProductAType type)
        {
            AbstractProductA product = null;

            switch(type)
            {
                case ProductAType.TYPE1:
                    product = new ProductAF1T1();
                    break;

                case ProductAType.TYPE2:
                    product = new ProductAF1T2();
                    break;
            }

            return product;
        }

        public AbstractProductB CreateProductB()
        {
            return new ProductBF1();
        }
    }

    class ConreteFactory2 : AbstractFactory
    {
        public AbstractProductA CreateProductA(ProductAType type)
        {
            AbstractProductA product = null;

            switch (type)
            {
                case ProductAType.TYPE1:
                    product = new ProductAF2T1();
                    break;

                case ProductAType.TYPE2:
                    product = new ProductAF2T2();
                    break;
            }

            return product;
        }

        public AbstractProductB CreateProductB()
        {
            return new ProductBF2();
        }
    }

    class Context
    {
        private AbstractFactory factory;
        public Context(AbstractFactory factory)
        {
            this.factory = factory;
        }

        public void SetFactory(AbstractFactory factory)
        {
            this.factory = factory;
        }

        public void DoSomething()
        {
            ProductAType[] types = { ProductAType.TYPE1, ProductAType.TYPE2 };
            
            foreach(ProductAType type in types)
            {
                AbstractProductA productA = factory.CreateProductA(type);
                System.Console.WriteLine(productA.Method1());
            }

            AbstractProductB productB = factory.CreateProductB();
            System.Console.WriteLine(productB.Method2());
        }
    }

    class AbstractFactoryPattern
    {
        public static void Test()
        {
            ConreteFactory1 factory1 = new ConreteFactory1();
            ConreteFactory2 factory2 = new ConreteFactory2();
            Context ctx = new Context(factory1);
            ctx.DoSomething();

            ctx.SetFactory(factory2);
            ctx.DoSomething();
        }
    }

}
