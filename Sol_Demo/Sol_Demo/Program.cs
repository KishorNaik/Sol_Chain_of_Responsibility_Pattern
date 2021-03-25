using Sol_Demo.Concreate;
using Sol_Demo.Contexts;
using Sol_Demo.Cores;
using Sol_Demo.Request;
using System;
using System.Threading;

namespace Sol_Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LeaveRequest leaveRequest = new LeaveRequest()
            {
                EmployeeName = "Kishor",
                LeaveDays = 10
            };

            ILeaveRequestHandler<LeaveRequest> supervisor = new SupervisorConcreate();
            ILeaveRequestHandler<LeaveRequest> manager = new ProjectManagerConcreate();
            ILeaveRequestHandler<LeaveRequest> hr = new HRConcreate();

            LeaveContext leaveContext = new LeaveContext();
            leaveContext
            .Register<LeaveRequest>(supervisor, manager)
            .Register<LeaveRequest>(manager, hr)
            .Register<LeaveRequest>(hr, null)
            .Run<LeaveRequest>(leaveRequest);
        }
    }
}