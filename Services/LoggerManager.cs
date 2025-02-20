using NLog;
using Services.Contracts;

namespace Services;
public class LoggerManager : ILoggerService
{
    private static ILogger logger = LogManager.GetCurrentClassLogger();
    public Task LogInfoAsync(string message)
    {
        logger.Info(message);
        return Task.CompletedTask;
    }

    public Task LogDebugAsync(string message)
    {
        logger.Debug(message);
        return Task.CompletedTask;
    }


    public Task LogErrorAsync(string message)
    {
        logger.Error(message);
        return Task.CompletedTask;
    }

    public Task LogWarningAsync(string message)
    {
        logger.Warn(message);
        return Task.CompletedTask;
    }
}
