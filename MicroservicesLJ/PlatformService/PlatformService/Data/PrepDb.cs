using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }

    private static void SeedData(AppDbContext? context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (!context.Platforms.Any())
        {
            Console.WriteLine("v2 Seeding data");
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