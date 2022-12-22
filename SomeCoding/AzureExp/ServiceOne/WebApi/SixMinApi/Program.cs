using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SixMinApi.Data;
using SixMinApi.Dtos;
using SixMinApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionBuilder = new SqlConnectionStringBuilder();
sqlConnectionBuilder.ConnectionString = builder.Configuration.GetConnectionString("SqlDbConnection");
sqlConnectionBuilder.UserID = builder.Configuration["UserId"];
sqlConnectionBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnectionBuilder.ConnectionString));
builder.Services.AddScoped<ICommandRepo, CommandRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/commands", async (ICommandRepo repo, IMapper mapper) =>
{
    var commands = await repo.GetAllCommands();
    return Results.Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
});

app.MapGet("api/v1/commands/{id}", async (ICommandRepo repo, IMapper mapper, int id) =>
{
    var command = await repo.GetCommandById(id);
    if (command != null)
    {
        return Results.Ok(mapper.Map<CommandReadDto>(command));
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("api/v1/commands", async (ICommandRepo repo, IMapper mapper, CommandCreateDto commandCreateDto) =>
{
    var command = mapper.Map<Command>(commandCreateDto);
    await repo.CreateCommand(command);
    await repo.SaveChangesAsync();

    var cmdRead = mapper.Map<CommandReadDto>(command);
    
    return Results.Created($"api/v1/commands/{command.Id}", cmdRead);
});

app.MapPut("api/v1/commands{id}", async (ICommandRepo repo, IMapper mapper, int id, CommandUpdateDto commandDto) =>
{
    var command = await repo.GetCommandById(id);
    if (command == null)
    {
        return Results.NotFound();
    }

    mapper.Map(commandDto, command);
    await repo.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/v1/commands{id}", async (ICommandRepo repo, IMapper mapper, int id) =>
{
    var command = await repo.GetCommandById(id);
    if (command == null)
    {
        return Results.NotFound();
    }

    repo.DeleteCommand(command);
    await repo.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
