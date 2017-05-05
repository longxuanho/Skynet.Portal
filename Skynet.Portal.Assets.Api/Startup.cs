using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Skynet.Portal.Assets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Skynet.Portal.Assets.Api.Services;
using Skynet.Portal.Assets.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Skynet.Portal.Assets.Api.Helpers;

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

            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:thietbis",
                    policy => policy.Requirements.Add(new HasScopeRequirement("read:thietbis", domain)));
                options.AddPolicy("manage:thietbis",
                    policy => policy.Requirements.Add(new HasScopeRequirement("manage:thietbis", domain)));
            });

            var connectionString = Configuration["connectionStrings:thucLucDBConnectionString"];
            services.AddDbContext<ThucLucContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IThucLucRepository, ThucLucRepository>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug(LogLevel.Information);

            var authOptions = new JwtBearerOptions
            {
                Audience = Configuration["Auth0:Audience"],
                Authority = $"https://{Configuration["Auth0:Domain"]}/"
            };
            app.UseJwtBearerAuthentication(authOptions);

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
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global Exception Logger");
                            logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                        }

                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Có lỗi xảy ra từ phía server. Vui lòng thử lại sau.");
                    });
                });
            }

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ThietBi, ThietBiDto>();
                cfg.CreateMap<ThietBiForCreationDto, ThietBi>();
                cfg.CreateMap<ThietBiForUpdateDto, ThietBi>();
            });

            app.UseMvc();
        }

    }
}
