namespace Services.Contracts;
public interface ILoggerService
{
    Task LogInfoAsync(string message);
    Task LogWarningAsync(string message);
    Task LogErrorAsync(string message);
    Task LogDebugAsync(string message);
}
