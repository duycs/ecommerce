using Hangfire;
using System;
using System.Threading.Tasks;

namespace Scheduler.Jobs
{
    [AutomaticRetry(Attempts = 0)]
    public interface ICronJob
    {
        Task Run();
    }
}
