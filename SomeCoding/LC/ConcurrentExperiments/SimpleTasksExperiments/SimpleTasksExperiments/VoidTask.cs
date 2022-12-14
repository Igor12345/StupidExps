using System.Diagnostics;

namespace SimpleTasksExperiments;

public class VoidTask
{
    private readonly Stopwatch _stopwatch;

    public VoidTask(Stopwatch stopwatch)
    {
        _stopwatch = stopwatch ?? throw new ArgumentNullException(nameof(stopwatch));
    }
    
    public void DoIt()
    {
        Console.WriteLine($"Before delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
        Task.Delay(1000).GetAwaiter().GetResult();
        Console.WriteLine($"After delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
    }

    public async void DoItAsync()
    {
        Console.WriteLine($"Before delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
        await Task.Delay(1000).ConfigureAwait(true);
        Console.WriteLine($"After delay {Thread.CurrentThread.ManagedThreadId},  {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
    }

    public async void DoItAsyncWithExceptionBefore()
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

    public async void DoItAsyncWithExceptionAfter()
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