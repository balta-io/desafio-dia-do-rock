using System.Text.Json;

namespace DesafioDiaDoRock.ApplicationCore.Extension;

public static class JsonExtension
{
    public static string ToJson(this object obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}
