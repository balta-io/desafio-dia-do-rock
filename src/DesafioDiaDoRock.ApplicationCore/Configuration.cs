namespace DesafioDiaDoRock.ApplicationCore
{
    public static class Configuration
    {
        public const int DefaultStatusCode = 200;
        public static string BackendUrl { get; set; } = "https://localhost:7241";
        public static string FrontendUrl { get; set; } = "https://localhost:7242";
        public static string GoogleApiKey { get; set; } = "AIzaSyAqN-qevL5e5RtlGTbcUwEVkh7vi6MPcuM";
    }
}
