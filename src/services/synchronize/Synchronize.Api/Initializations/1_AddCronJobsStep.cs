using ECommerce.Shared.Dotnet.Initialization;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Synchronize.Api.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Synchronize.Api.Initializations
{
    public class AddCronJobsStep : IInitializationStep
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public int Order => 1;

        public AddCronJobsStep(IServiceProvider serviceProvider,
            IWebHostEnvironment hostingEnvironment)
        {
            _serviceProvider = serviceProvider;
            _hostingEnvironment = hostingEnvironment;
        }

        public Task ExecuteAsync()
        {
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            var tasks = File.ReadAllText(Path.Combine(contentRootPath, "Setup", "scheduled-tasks.json"));

            TaskUtils.AllTasks = new Dictionary<string, ScheduledTask>(JsonConvert
                    .DeserializeObject<List<ScheduledTask>>(tasks)
                    .ToDictionary(task => task.Id, task => task));
            TaskUtils.AddConfiguredCronJob(_serviceProvider, TaskUtils.AllTasks.ToDictionary(t => t.Key, t => t.Value.CronExpression));
            return Task.CompletedTask;
        }
    }
}
