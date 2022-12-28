// See https://aka.ms/new-console-template for more information

using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

class Program
{
   static void Main(string[] args)
   {
      Console.WriteLine("Hello, World!");

      IConfiguration builtConfig = new ConfigurationBuilder()
         .AddJsonFile("appsettings.json")
         .AddEnvironmentVariables()
         .Build();
      TokenCredential credential = new ClientSecretCredential(builtConfig["Azure:tenantId"],
         builtConfig["Azure:ClientId"], builtConfig["Azure:ClientSecret"]);
      Uri vaultUri = new Uri(builtConfig["Azure:KeyVault:DNS"]);

      SecretClientOptions options = new SecretClientOptions()
      {
         Retry =
         {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
      };

      SecretClient client = new SecretClient(vaultUri, credential, options);
      var secretName = builtConfig["Azure:SecretName"];
      Response<KeyVaultSecret>? secretResponse = client.GetSecret(secretName);
      KeyVaultSecret secret = secretResponse.Value;
      string value = secret.Value;

      var builder = CreateHostBuilder(args);
      builder.Build().Run();
   }

   public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, configBuilder) =>
      {
         var builtConfig = configBuilder.Build();
         TokenCredential credential = new ClientSecretCredential(builtConfig["Azure:tenantId"],
            builtConfig["Azure:ClientId"], builtConfig["Azure:ClientSecret"]);
         Uri vaultUri = new Uri(builtConfig["Azure:KeyVault:DNS"]);
         var builder = configBuilder.AddAzureKeyVault(vaultUri, credential);
      });

}