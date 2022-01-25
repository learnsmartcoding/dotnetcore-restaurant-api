namespace KarthikTechBlog.Restaurant.CrossCutting.Extensions
{
    public static class StringExtensions
    {
        public static string ToUpperOrEmpty(this string input)
        {
            return input?.ToUpper()?.Trim() ?? string.Empty;
        }
    }
}
