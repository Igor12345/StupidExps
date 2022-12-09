using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using CommandService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers;

[Route("api/c/platforms/{platformId}/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommandRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommandRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetCommandsFoPlatform(int platformId)
    {
        Console.WriteLine($"Getting commands for the platform {platformId}");

        if (!_repository.PlatformExists(platformId))
        {
            return NotFound();
        }

        var commands = _repository.GetCommandsForPlatform(platformId);

        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
    }

    [HttpGet("commandId", Name = "GetCommandForPlatform")]
    public ActionResult<IEnumerable<CommandReadDto>> GetCommandForPlatform(int platformId, int commandId)
    {
        Console.WriteLine($"Getting command for the platform {platformId}/{commandId}");
        if (!_repository.PlatformExists(platformId))
        {
            return NotFound();
        }

        Command command = _repository.GetCommand(platformId, commandId);

        if (command == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CommandReadDto>(command));
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandDto)
    {
        Console.WriteLine($"Creating command for the platform {platformId}");
        if (!_repository.PlatformExists(platformId))
        {
            return NotFound();
        }

        Command command = _mapper.Map<Command>(commandDto);

        _repository.CreateCommand(platformId, command);
        _repository.SaveChanges();
        CommandReadDto commandReadDto = _mapper.Map<CommandReadDto>(command);

        return CreatedAtRoute(nameof(GetCommandForPlatform), new
        {
            platformId = platformId, commandId = commandReadDto.Id
        }, commandReadDto);
    }

}