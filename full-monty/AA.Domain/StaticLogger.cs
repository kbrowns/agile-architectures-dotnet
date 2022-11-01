using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AA.Domain;

/// <summary>
/// The purpose of this class is to be a static logging interface.  The Microsoft logging framework is based on
/// dependency injection (DI), but offers no way to log statically - i.e. from static classes.  This is a philosophical
/// subject, but I subscribe to the school of thought that says the logging interface should be
/// accessible from everywhere - not just injected object instances.  Others might disagree, but it's my experience/belief
/// that logger injection muddies the system design and makes it hard to log at lower levels in the architecture.
/// Logging shouldn't be hard anywhere.
///
/// This class is a thin wrapper around ILogger and the factory that creates it such that a static instead of this class can
/// live in each class in the system that writes logs.
/// </summary>
public class StaticLogger : ILogger
{
    private ILogger _instance;
    private volatile object _instanceLocker = new();
    private readonly Type _callingType;

    public StaticLogger(Type callingType)
    {
        _callingType = callingType;
    }

    private ILogger Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_instanceLocker)
                {
                    var loggerFactory = ServiceProviderRoot.Services.GetRequiredService<ILoggerFactory>();
                    _instance = loggerFactory.CreateLogger(_callingType);
                }
            }

            return _instance;
        }
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        this.Instance.Log(logLevel, eventId, state, exception, formatter);
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return this.Instance.IsEnabled(logLevel);
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return this.Instance.BeginScope(state);
    }
}
