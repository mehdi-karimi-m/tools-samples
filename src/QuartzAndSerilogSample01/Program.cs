using Serilog;

namespace QuartzAndSerilogSample01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    Bootstrapper.WireUp(services, hostBuilderContext.Configuration);
                })
                .UseSerilog(
                (hostBuilderContext, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
                }
                )
                .Build();

            host.Run();
        }
    }
}