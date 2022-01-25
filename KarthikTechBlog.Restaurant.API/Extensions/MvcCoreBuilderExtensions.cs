using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace KarthikTechBlog.Restaurant.API.Extensions
{
    public static class MvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder AddCustomCors(this IMvcCoreBuilder builder, IConfiguration config)
        {
            var hosts = config.GetSection("allowedHosts")?.Get<List<string>>().ToArray();

            builder.AddCors(
                options =>
                {
                    // Create named CORS policies here which you can consume using application.UseCors("PolicyName")
                    // or a [EnableCors("PolicyName")] attribute on your controller or action.
                    options.AddPolicy("AllowAny",
                      x => x
                          .WithOrigins(hosts)
                          .AllowAnyMethod()
                          .AllowAnyHeader());
                });

            return builder;
        }
    }
}
