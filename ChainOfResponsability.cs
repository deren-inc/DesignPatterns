using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Object version of switch-case instruction 
 */

namespace Patterns.ChainOfResponsability
{
    enum RequestType
    {
        REQ_HANDLER1,
        REQ_HANDLER2,
        REQ_HANDLER3
    }

    class Request
    {
        string description = string.Empty;
        RequestType reqType;
         
        public Request(string description, RequestType type)
        {
            this.description = description;
            this.reqType = type;
        }

        public RequestType GetRequestType()
        {
            return reqType;
        }

        public string GetDescription()
        {
            return description;
        }
    }

    abstract class ChainHandler
    {
        private ChainHandler nextChain = null;

        public void SendRequestToNextHandler(Request request)
        {
            if (nextChain != null)
                nextChain.Handle(request);
        }

        public void Handle(Request request)
        {
            if (CanHandleRequest(request))
                ProcessRequest(request);
            else
                SendRequestToNextHandler(request);
        }

        public void SetNextChain(ChainHandler next)
        {
            nextChain = next;
        }

        protected abstract bool CanHandleRequest(Request request);
        protected abstract void ProcessRequest(Request request);
    }

    class Handler1 : ChainHandler
    {
        protected override bool CanHandleRequest(Request request)
        {
            return request.GetRequestType() == RequestType.REQ_HANDLER1;
        }

        protected override void ProcessRequest(Request request)
        {
            System.Console.WriteLine("Handler1 is handling a request: " + request.GetDescription());
        }
    }

    class Handler2 : ChainHandler
    {
        protected override bool CanHandleRequest(Request request)
        {
            return request.GetRequestType() == RequestType.REQ_HANDLER2;
        }

        protected override void ProcessRequest(Request request)
        {
            System.Console.WriteLine("Handler2 is handling a request: " + request.GetDescription());
        }
    }


    class Handler3 : ChainHandler
    {
        protected override bool CanHandleRequest(Request request)
        {
            return request.GetRequestType() == RequestType.REQ_HANDLER3;
        }

        protected override void ProcessRequest(Request request)
        {
            System.Console.WriteLine("Handler3 is handling a request: " + request.GetDescription());
        }
    }

    class ChainOfResponsabilityPattern
    {
        public static void Test()
        {
            Handler1 h1 = new Handler1();
            Handler2 h2 = new Handler2();
            Handler3 h3 = new Handler3();

            h1.SetNextChain(h2);
            h2.SetNextChain(h3);

            Request request = new Request("task1211", RequestType.REQ_HANDLER2);
            h1.Handle(request);
        }
    }
}
