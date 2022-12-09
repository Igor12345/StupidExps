using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;

    public PlatformsController(IPlatformRepo repository, IMapper mapper, ICommandDataClient commandDataClient)
    {
        _repository = repository;
        _mapper = mapper;
        _commandDataClient = commandDataClient;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("Getting platforms");
        var platforms = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platform = _repository.GetPlatformById(id);
        if (platform != null)
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        var platform = _mapper.Map<Platform>(platformCreateDto);
        if (platform != null)
        {
            _repository.CreatePlatform(platform);
            _repository.SaveChanges();
            var platformDto = _mapper.Map<PlatformReadDto>(platform);
            Console.WriteLine($"Trying to call command service");

            try
            {
                await _commandDataClient.SendPlatformToCommand(platformDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not send synchronously: {e.Message}");
                try
                {
                    Console.WriteLine($"Trying to call WeatherForecast");
                    await _commandDataClient.GetWeatherForecast();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not get WeatherForecast: {ex.Message}");
                }
            }

            return CreatedAtAction(nameof(GetPlatformById), new { Id = platform.Id }, platformDto);
        }

        return BadRequest();
    }
}