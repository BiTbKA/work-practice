using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduledTask.Jobs
{
    public class MyTask : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            this.Func();

        }

        public void Func()
        {
            Console.WriteLine("//====//===//====//===//====//===//====//===//");
            Console.WriteLine("Schedule task is started.");
            Console.WriteLine("Schedule task is finished.");
            Console.WriteLine("//====//===//====//===//====//===//====//===//");
        }
    }
}
