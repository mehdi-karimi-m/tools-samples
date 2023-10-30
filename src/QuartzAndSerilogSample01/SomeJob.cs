using Quartz;

namespace QuartzAndSerilogSample01
{
    internal class SomeJob : IJob
    {
        private readonly ILogger<SomeJob> _logger;

        public SomeJob(ILogger<SomeJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Some job executed");
            _logger.LogTrace("This is trace {@context}", context);
            return Task.CompletedTask;
        }
    }
}
