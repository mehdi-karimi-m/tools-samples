using Quartz;

namespace QuartzAndSerilogSample01
{
    internal static class Bootstrapper
    {
        public static void WireUp(IServiceCollection services, IConfiguration configuration)
        {
            services.AddQuartz(scqc =>
            {
                scqc.ScheduleJob<SomeJob>(trigger => trigger.WithIdentity("trigger1", "group1")
                                                            .WithSimpleSchedule(x => x.WithIntervalInSeconds(10)
                                                                                      .RepeatForever()),
                                          job => job.WithIdentity("job1", "group1")
                                         );
            });
            services.AddQuartzHostedService(quartzHostedServiceOptions =>
            {

            });
        }
    }
}
