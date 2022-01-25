using AutoMapper;
using KarthikTechBlog.Restaurant.API.Extensions;
using KarthikTechBlog.Restaurant.Data;
using KarthikTechBlog.Restaurant.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace KarthikTechBlog.Restaurant.API
{
    public class Startup
    {
        private const string CorsName = "AllRequests";

        public Startup(IWebHostEnvironment  webHostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(webHostEnvironment.ContentRootPath)
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .AddJsonFile($"appsettings.{webHostEnvironment.EnvironmentName}.json", optional: true)
                          .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<RestaurantDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DbContext"))
            );

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFoodMenusRepository, FoodMenusRepository>();
            services.AddScoped<IFoodImagesRepository, FoodImagesRepository>();
            services.AddScoped<ICuisineRepository, CuisineRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICuisineServices, CuisineServices>();
            services.AddScoped<IFoodMenusServices, FoodMenusServices>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo()
                    {
                        Title = "KarthikTechBlog Restaurant API",
                        Version = "V1",
                        Description = "",
                        TermsOfService = new System.Uri("https://karthiktechblog.com/copyright"),
                        Contact = new OpenApiContact()
                        {
                            Name = "Karthik Kannan KD",
                            Email = "karthiktechblog.com@gmail.com",
                            Url = new System.Uri("http://www.karthiktechblog.com")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new System.Uri("https://karthiktechblog.com/copyright"),
                        }
                    });
                }
            );

           
            services.AddCors(options =>
            {
                options.AddPolicy("AllRequests", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => origin == "http://localhost:4200" ||
                    origin == "http://localhost:4300")
                    .AllowCredentials();
                });
            });

            services
            .AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_CONNECTIONSTRING"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllRequests");

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseCors("AllowAny");

            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Karthiktechblog Restaurant API V1");
            });


        }
    }
}
