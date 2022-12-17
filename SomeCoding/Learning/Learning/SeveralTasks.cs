public class SeveralTasks
{
    public async Task<int> JustRun()
    {
        Console.WriteLine("Inside method");
        await Task.Delay(5);
        Console.WriteLine("Before exception");
        throw new InvalidOperationException("42");
    }
}