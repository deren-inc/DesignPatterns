using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Proxy
{
    interface Subject
    {
        string Method();
    }

    class RealSubject : Subject
    {
        public string Method()
        {
            return "proxy pattern";
        }
    }

    class Proxy : Subject
    {
        private RealSubject realSubject = null;

        private void CreateSubject()
        {
            if(realSubject == null)
            {
                realSubject = new RealSubject();
            }
        }

        public string Method()
        {
            CreateSubject();
            return realSubject.Method();
        }
    }

    class ProxyPattern
    {
        private static void f(Subject s)
        {
            System.Console.WriteLine(s.Method());
        }
        public static void Test()
        {
            Proxy proxy = new Proxy();
            f(proxy);
        }
    }
}
