﻿namespace DesafioDiaDoRock.ApplicationCore
{
    public static class Configuration
    {
        public const int DefaultStatusCode = 200;
        public static string BackendUrl { get; set; } = Environment.GetEnvironmentVariable("BackendUrl") ?? "https://localhost:7241";
        public static string FrontendUrl { get; set; } = Environment.GetEnvironmentVariable("FrontendUrl") ?? "https://localhost:7242";
        public static string GoogleApiKey { get; set; } = Environment.GetEnvironmentVariable("GoogleApiKey") ?? "AIzaSyAqN-qevL5e5RtlGTbcUwEVkh7vi6MPcuM";
        public static string SECRET { get; set; } = Environment.GetEnvironmentVariable("SECRETJWT") ?? "40ceff0fb8965706f8a0667c12156771";
      
    }
}
