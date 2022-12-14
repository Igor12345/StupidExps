using System.Diagnostics;

namespace SimpleTasksExperiments;

public class Manager
{
    public void Execute()
    {
        try
        {
            Stopwatch stopwatch = new Stopwatch();
            var task = new SimpleTask(stopwatch);
            stopwatch.Start();
            Console.WriteLine($"In main method before {Thread.CurrentThread.ManagedThreadId}, {stopwatch.Elapsed.Minutes}:{stopwatch.Elapsed.Seconds}:{stopwatch.Elapsed.Milliseconds}");

            task.DoItAsyncWithExceptionAfter().SafeFireAndForget(e =>
            {
                Console.WriteLine($"Inside safe {Thread.CurrentThread.ManagedThreadId}");
                // throw e;
            });
            Console.WriteLine($"In main method after {Thread.CurrentThread.ManagedThreadId}, {stopwatch.Elapsed.Minutes}:{stopwatch.Elapsed.Seconds}:{stopwatch.Elapsed.Milliseconds}");
        
            Task.Delay(2000).GetAwaiter().GetResult();
        
            Console.WriteLine($"In main method end {Thread.CurrentThread.ManagedThreadId}, {stopwatch.Elapsed.Minutes}:{stopwatch.Elapsed.Seconds}:{stopwatch.Elapsed.Milliseconds}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"In manager catch {Thread.CurrentThread.ManagedThreadId} - {e.Message}");
            throw;
        }
    }
}