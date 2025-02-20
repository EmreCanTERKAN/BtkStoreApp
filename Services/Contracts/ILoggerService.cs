namespace Services.Contracts;
public interface ILoggerService
{
    Task LogAsync(string message);
    Task LogWarningAsync(string message);
    Task LogErrorAsync(string message);
    Task LogDebugAsync(string message);
}
