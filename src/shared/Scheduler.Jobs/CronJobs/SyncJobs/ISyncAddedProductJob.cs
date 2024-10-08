using Hangfire;

namespace Scheduler.Jobs.CronJobs.SyncJobs
{
    [Queue("synchronize"), AutomaticRetry(Attempts = 0)]
    public interface ISyncAddedProductJob : ICronJob
    {
    }
}
