using Sol_Demo.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Contexts
{
    public class LeaveContext
    {
        private readonly List<dynamic> leaveRequestHandlers = new List<dynamic>();

        public LeaveContext Register<TRequest>(ILeaveRequestHandler<TRequest> concreteHandler, ILeaveRequestHandler<TRequest> nextHandler)
        {
            ((ILeaveRequestHandler<TRequest>)concreteHandler).NextHandler = nextHandler;
            leaveRequestHandlers.Add(concreteHandler);
            return this;
        }

        public void Run<TRequest>(TRequest request)
        {
            ((ILeaveRequestHandler<TRequest>)
                 leaveRequestHandlers
                 .AsParallel()
                 .AsSequential()
                 .FirstOrDefault()
             )?.Handle(request);
        }
    }
}