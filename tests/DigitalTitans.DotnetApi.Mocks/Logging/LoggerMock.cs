using Microsoft.Extensions.Logging;

namespace DigitalTitans.DotnetApi.Mocks.Logging;

public abstract class LoggerMock<T> : ILogger<T>
{
    void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var unboxed = (IReadOnlyList<KeyValuePair<string, object>>)state!;
        string message = formatter(state, exception);

        Log();
        Log(logLevel, message, exception);
        Log(logLevel, unboxed.ToDictionary(k => k.Key, v => v.Value), exception);
    }

    public abstract void Log();

    public abstract void Log(LogLevel logLevel, string message, Exception? exception = null);

    public abstract void Log(LogLevel logLevel, IDictionary<string, object> state, Exception? exception = null);

    public virtual bool IsEnabled(LogLevel logLevel) => true;

    public abstract IDisposable? BeginScope<TState>(TState state) where TState : notnull;
}
