namespace Utils;

using Serilog;

public static class Log
{
  public static ILogger Logger { get; set; } =
    new LoggerConfiguration().WriteTo.Console().CreateLogger();
}


// log = new LoggerConfiguration()
//     .WriteTo.Console()
//     .CreateLogger();
