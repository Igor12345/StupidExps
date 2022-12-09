using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
    }

    private static void SeedData(AppDbContext? context, bool isProduction)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (isProduction)
        {
            Console.WriteLine("Attempting to apply migrations");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not apply migrations {e.Message}");
            }
        }
        
        if (!context.Platforms.Any())
        {
            Console.WriteLine("v3 Seeding data");
            context.Platforms.AddRange(
                new Platform()
                {
                    Name = "Dot Net",
                    Publisher = "Microsoft",
                    Cost = "free"
                },
                new Platform()
                {
                    Name = "MS SQL Server",
                    Publisher = "Microsoft",
                    Cost = "free"
                },
                new Platform()
                {
                    Name = "Kubernetes",
                    Publisher = "Cloud Native Computing Foundation",
                    Cost = "free"
                });
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Already have data");
        }

    }
}