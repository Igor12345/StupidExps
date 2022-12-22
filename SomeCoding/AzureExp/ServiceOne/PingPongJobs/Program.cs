using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PingPongJobs
{
   class Program
   {
      static async Task Main()
      {
         var builder = new HostBuilder();

         using IHost host1 = Host.CreateDefaultBuilder().Build();
         IConfiguration configFromHosting = host1.Services.GetRequiredService<IConfiguration>();

         builder.UseEnvironment(EnvironmentName.Development);

         

         IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
         var resolver = new CustomNameResolver(config);

         // builder.ConfigureAppConfiguration((bc, cb) =>
         // {
         //    cb.AddJsonFile("appsettings.json")
         //       .AddEnvironmentVariables()
         //       .Build();
         // });

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
         builder.ConfigureServices(s => s.AddSingleton<IConfiguration>(config));
         builder.ConfigureServices(s => s.AddSingleton<INameResolver>(resolver));
         var host = builder.Build();
         using (host)
         {
            await host.RunAsync();
         }
      }
   }
}