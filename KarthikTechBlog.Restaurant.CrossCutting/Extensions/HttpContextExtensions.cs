using Microsoft.AspNetCore.Http;

namespace KarthikTechBlog.Restaurant.CrossCutting.Extensions
{
    public static class HttpContextExtensions
    {
        public static void Caller<T>(this HttpContext context) => context.Items["caller"] = typeof(T).ToString();
    }
}
