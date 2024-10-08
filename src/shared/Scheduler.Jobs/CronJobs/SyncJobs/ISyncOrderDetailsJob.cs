using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Jobs.CronJobs.SyncJobs
{
    [Queue("synchronize"), AutomaticRetry(Attempts = 0)]
    public interface ISyncOrderDetailsJob : ICronJob
    {
    }
}
