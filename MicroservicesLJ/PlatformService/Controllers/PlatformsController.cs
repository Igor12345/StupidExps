using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        var platform = _mapper.Map<Platform>(platformCreateDto);
        if (platform != null)
        {
            _repository.CreatePlatform(platform);
            _repository.SaveChanges();
            var platformDto = _mapper.Map<PlatformReadDto>(platform);
            return CreatedAtAction(nameof(GetPlatformById), new { Id = platform.Id }, platformDto);
        }

        return BadRequest();
    }
}