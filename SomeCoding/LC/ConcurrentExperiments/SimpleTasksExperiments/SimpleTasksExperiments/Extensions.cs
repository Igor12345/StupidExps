namespace SimpleTasksExperiments;

public static class Extensions
{
    public static void SafeFireAndForget(this Task task, in Action<Exception>? onException = null,
        in bool continueOnCapturedContext = false) =>
        HandleSafeFireAndForget(task, continueOnCapturedContext, onException);

    public static void SafeFireAndForget<TException>(this Task task, in Action<TException>? onException = null,
        in bool continueOnCapturedContext = false) where TException : Exception =>
        HandleSafeFireAndForget(task, continueOnCapturedContext, onException);


    static async void HandleSafeFireAndForget<TException>(Task task, bool continueOnCapturedContext,
        Action<TException>? onException) where TException : Exception
    {
        try
        {
            await task.ConfigureAwait(continueOnCapturedContext);
        }
        catch (TException ex) when (onException is not null)
        {
            onException?.Invoke(ex);
        }
    }

    static void HandleException<TException>(in TException exception, in Action<TException>? onException)
        where TException : Exception
    {
        onException?.Invoke(exception);
    }
}