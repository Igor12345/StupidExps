using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PingPongJobs
{
   class Program
   {
      static async Task Main()
      {
         var builder = new HostBuilder();
         builder.UseEnvironment(EnvironmentName.Development);
         builder.ConfigureWebJobs(b =>
         {
            b.AddAzureStorageCoreServices();
            b.AddAzureStorageQueues();
         });
         builder.ConfigureLogging((context, b) =>
         {
            b.AddConsole();
            b.SetMinimumLevel(LogLevel.Warning);
            string instrumentationKey = context.Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"];
            if (!string.IsNullOrEmpty(instrumentationKey))
            {
               b.AddApplicationInsightsWebJobs(o => o.InstrumentationKey = instrumentationKey);
            }
         });
         var host = builder.Build();
         using (host)
         {
            await host.RunAsync();
         }
      }
   }
}