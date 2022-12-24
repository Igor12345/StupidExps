using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Azure;
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
         var builder = Host.CreateDefaultBuilder();

         builder.UseEnvironment(Environments.Production);
         
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
         builder.ConfigureAppConfiguration(AddAppConfiguration);
         // IConfiguration config = new ConfigurationBuilder()
         //    .AddJsonFile("appsettings.json")
         //    .AddEnvironmentVariables()
         //    .Build();
         //
         // // builder.Configuration
         // // builder.
         //
         // var resolver = new CustomNameResolver(config);

         // builder.ConfigureServices(s => s.AddSingleton<IConfiguration>(config));
         builder.ConfigureServices(s => s.AddSingleton<INameResolver, CustomNameResolver>());
         // builder.ConfigureServices(s => s.AddScoped<CustomNameResolver>());
         
        

         IHost host = builder.Build();
         IConfiguration configFromHosting = host.Services.GetService<IConfiguration>()!;
         
         
         
         using (host)
         {
            await host.RunAsync();
         }
      }

      private static void AddAppConfiguration(HostBuilderContext hostingContext, IConfigurationBuilder config)
      {
         var env = hostingContext.HostingEnvironment;
         config.Sources.Clear();
         config.AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
         config.AddEnvironmentVariables();
         // config.AddUserSecrets()

      }
      public IConfiguration Configuration { get; }
   }
   
}