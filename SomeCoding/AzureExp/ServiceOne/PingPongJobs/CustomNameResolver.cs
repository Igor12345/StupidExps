using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;

namespace PingPongJobs;

public class CustomNameResolver : INameResolver
{
   private readonly IConfiguration _config;

   // public CustomNameResolver()
   // {
   //    
   // }

   public CustomNameResolver(IConfiguration config)
   {
      _config = config;
   }

   public string? Resolve(string name)
   {
      // return "custom-queue-dev";
      string? value = _config.GetRequiredSection(name).Value;
      return value;
   }
}