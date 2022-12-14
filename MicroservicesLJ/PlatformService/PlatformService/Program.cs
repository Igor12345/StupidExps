using Microsoft.EntityFrameworkCore;
using PlatformService.AsyncDataServices;
using PlatformService.Data;
using PlatformService.SyncDataServices.Grpc;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (builder.Environment.IsProduction())
{
    Console.WriteLine(" Production Environment, using SqlServer db.");
    Console.WriteLine($"Connection: {builder.Configuration.GetConnectionString("PlatformsConnection")}");
    Console.WriteLine($"Connection 2: {builder.Configuration["ConnectionString.PlatformsConnection"]}");
    builder.Services.AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConnection"));
    });
}
else
{
    Console.WriteLine(" Development Environment, using InMem db.");
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseInMemoryDatabase("InMem"));
}

builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
builder.Services.AddGrpc();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

 // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
Console.WriteLine($"v3 Command service endpoint is {builder.Configuration["CommandService"]}");

// app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapGrpcService<GrpcPlatformService>();

        endpoints.MapGet("/protos/platforms.proto", async context =>
        {
            await context.Response.WriteAsync(File.ReadAllText("Protos/platforms.proto"));
        });
    }
);

// app.MapControllers();
PrepDb.PrepPopulation(app, builder.Environment.IsProduction());

app.Run();
