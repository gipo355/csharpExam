namespace Config;

using dotenv.net;

public static class Environment
{
  public static IDictionary<string, string> EnvVars { get; }

  // private static void LoadEnv() => DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../.env" }));

  static Environment()
  {
    DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../.env" }));
    // LoadEnv();
    EnvVars = DotEnv.Read();
  }
}
