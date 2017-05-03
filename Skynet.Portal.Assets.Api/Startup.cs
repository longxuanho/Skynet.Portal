using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Skynet.Portal.Assets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Skynet.Portal.Assets.Data.Services;
using Skynet.Portal.Assets.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Skynet.Portal.Assets.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var connectionString = Configuration["connectionStrings:thucLucDBConnectionString"];
            services.AddDbContext<ThucLucContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IThucLucRepository, ThucLucRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Có lỗi xảy ra từ phía server. Vui lòng thử lại sau.");
                    });
                });
            }

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ThietBi, ThietBiDto>();
                cfg.CreateMap<ThietBiForCreationDto, ThietBi>();
            });

            app.UseMvc();
        }

    }
}
