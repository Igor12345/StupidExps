using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http;

public class HttpCommandDataClient : ICommandDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task SendPlatformToCommand(PlatformReadDto plat)
    {
        var httpContent = new StringContent(
            JsonSerializer.Serialize(plat),
            Encoding.UTF8,
            "application/json"
        );
        Console.WriteLine($"Trying the url {_configuration["CommandService"]}");
        try
        {
            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync POST to CommandService was OK!");
            }
            else
            {
                Console.WriteLine("Sync POST to CommandService was NOT OK!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"The error occured during POST Platform {e.Message}");
            throw;
        }
    }

    public async Task GetWeatherForecast()
    {
        Console.WriteLine($"Trying to get WeatherForecast, the url {_configuration["CommandServiceBase"]}");
        try
        {
            await _httpClient.GetAsync($"{_configuration["CommandServiceBase"]}WeatherForecast");
        }
        catch (Exception e)
        {
            Console.WriteLine($"The error occured during Get WeatherForecast {e.Message}");
        }
    }
}