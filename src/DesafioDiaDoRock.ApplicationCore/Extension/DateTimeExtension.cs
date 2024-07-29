namespace DesafioDiaDoRock.ApplicationCore.Extension
{
    public static class DateTimeExtension
    {
        public static DateTime ToDateTime(this object? obj)
        {
            string? text = obj?.ToString();

            if (text is null) return new();

            DateTime.TryParse(text, out var date);

            return date;
        }
    }
}
