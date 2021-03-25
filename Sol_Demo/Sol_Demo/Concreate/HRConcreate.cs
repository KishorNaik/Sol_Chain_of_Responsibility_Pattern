using Sol_Demo.Cores;
using Sol_Demo.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Concreate
{
    public class HRConcreate : ILeaveRequestHandler<LeaveRequest>
    {
        ILeaveRequestHandler<LeaveRequest> ILeaveRequestHandler<LeaveRequest>.NextHandler { get; set; }

        void ILeaveRequestHandler<LeaveRequest>.Handle(LeaveRequest leaveRequest)
        {
            if (leaveRequest.LeaveDays > 30)
            {
                Console.WriteLine("Leave request:- Employee: {0}, Leave days: {1} - approved by HR", leaveRequest.EmployeeName, leaveRequest.LeaveDays);
            }
            else
            {
                ((ILeaveRequestHandler<LeaveRequest>)this).NextHandler.Handle(leaveRequest);
            }
        }
    }
}