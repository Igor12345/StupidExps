using System.Diagnostics;

namespace SimpleTasksExperiments;

public class SimpleTask
{
    private readonly Stopwatch _stopwatch;

    public SimpleTask(Stopwatch stopwatch)
    {
        _stopwatch = stopwatch ?? throw new ArgumentNullException(nameof(stopwatch));
    }
    
    public Task DoIt()
    {
        Console.WriteLine($"Before delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
        Task.Delay(1000).GetAwaiter().GetResult();
        Console.WriteLine($"After delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
        return Task.Factory.StartNew(() => true);
    }

    public async Task DoItAsync()
    {
        Console.WriteLine($"Before delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
        await Task.Delay(1000).ConfigureAwait(true);
        Console.WriteLine($"After delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
    }

    public async Task DoItAsyncWithExceptionBefore()
    {
        Console.WriteLine($"Before delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
        try
        {
            throw new InvalidOperationException("Error!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"In inner catch {Thread.CurrentThread.ManagedThreadId} - {e.Message}");
            throw;
        }
        await Task.Delay(1000);
        Console.WriteLine($"After delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
    } 

    public async Task DoItAsyncWithExceptionAfter()
    {
        Console.WriteLine($"Before delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
        
        await Task.Delay(1000);
        
        Console.WriteLine($"After delay before exception {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
        try
        {
            throw new InvalidOperationException("Error!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"In inner catch {Thread.CurrentThread.ManagedThreadId} - {e.Message}");
            throw;
        }
        Console.WriteLine($"After delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
    } 
}