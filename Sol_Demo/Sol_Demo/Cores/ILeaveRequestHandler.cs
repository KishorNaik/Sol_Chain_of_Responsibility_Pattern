using Sol_Demo.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Cores
{
    public interface ILeaveRequestHandler<IRequest>
    {
        void Handle(IRequest leaveRequest);

        ILeaveRequestHandler<IRequest> NextHandler { get; set; }
    }
}