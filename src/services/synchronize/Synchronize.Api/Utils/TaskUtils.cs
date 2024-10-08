using Hangfire;
using Hangfire.Common;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Synchronize.Api.Utils
{
    public static class TaskUtils
    {
        public static Dictionary<string, ScheduledTask> AllTasks { get; set; }

        public static string GetTitle(this Job job)
        {
            if (job == null)
            {
                return string.Empty;
            }

            var jobType = job.Type.Name;
            return AllTasks.TryGetValue(jobType, out var task) ? task.Title : (AllTasks.TryGetValue(jobType.Substring(1), out var task2) ? task2.Title : jobType);
        }

        public static void AddConfiguredCronJob(IServiceProvider serviceProvider, IDictionary<string, string> cronExpressions)
        {
            var definedTasks = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(ICronJob).IsAssignableFrom(t) && t.IsInterface && t != typeof(ICronJob))
                .ToList();

            var recurringJobManager = serviceProvider.GetRequiredService<IRecurringJobManager>();
            foreach (var task in definedTasks)
            {
                var name = new Regex("^I").Replace(task.Name, ""); // remove I prefix
                if (cronExpressions.TryGetValue(name, out var exp))
                {
                    var method = typeof(ICronJob).GetMethod(nameof(ICronJob.Run));
                    var queueName = task.GetCustomAttribute<QueueAttribute>()?.Queue;
                    var job = new Job(task, method);

                    if (string.IsNullOrEmpty(queueName))
                    {
                        throw new InvalidOperationException("Please set queue explicit");
                    }
                    recurringJobManager.AddOrUpdate(name, job, exp, options: new RecurringJobOptions()
                    {
                        TimeZone = TimeZoneInfo.FromSerializedString("Asia/Ho_Chi_Minh;420;Asia/Ho_Chi_Minh;+07;+07;;"),
                    });
                }
            }
        }
    }
}
