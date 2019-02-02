using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FactoryMethod
{
    enum ProductType
    {
        PRODUCT1,
        PRODUCT2
    }

    interface Product
    {
        string Method();
    }

    class Product1 : Product
    {
        public string Method()
        {
            return "Product1.method";
        }
    }

    class Product2 : Product
    {
        public string Method()
        {
            return "Product2.method";
        }
    }

    abstract class Creator
    {
        protected abstract Product FactoryMethod(ProductType type);
        public void Operation()
        {
            ProductType[] productTypes = { ProductType.PRODUCT1, ProductType.PRODUCT2 };

            foreach (ProductType type in productTypes)
            {
                Product product = FactoryMethod(type);
                System.Console.WriteLine(product.Method());
            }
        }
    }

    class ConcreteCreator : Creator
    {
        protected override Product FactoryMethod(ProductType type)
        {
            Product product = null;

            switch(type)
            {
                case ProductType.PRODUCT1:
                    product = new Product1();
                    break;
                case ProductType.PRODUCT2:
                    product = new Product2();
                    break;
            }

            return product;
        }
    }

    class FactoryMethodPattern
    {
        public static void Test()
        {
            ConcreteCreator creator = new ConcreteCreator();
            creator.Operation();
        }
    }
}
