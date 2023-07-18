


namespace SocialMedia.WebUI.Services;

public class SerilogService
{
    public static void SerilogSettings(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(configuration)
           .MinimumLevel.Information()
           .WriteTo.Console()
           .Enrich.FromLogContext()
           .Enrich.WithEnvironmentUserName()
           .Enrich.WithMachineName()
           .Enrich.WithClientIp()
           .WriteTo.TeleSink(
            telegramApiKey: configuration.GetConnectionString("TelegramToken1"),
            telegramChatId: "619670300",
            minimumLevel: LogEventLevel.Error)
           .CreateLogger();
    }

}
