using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Uva.Allergie.Application;
using Uva.Allergie.Application.Contracts;
using Uva.Allergie.Common.Helpers;
using Uva.Allergie.Common.Models;
using Uva.Allergie.Data.Context;

namespace Uva.Allergie.WebApi
{
    public class Startup
    {
        private readonly ILogger _logger;
        private AppSettingsOption _appSettingOptions;
        public Startup(IHostEnvironment env, ILogger<Startup> logger)
        {
            _logger = logger;
            var builder = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);
            Configuration = builder.Build();

            _logger.LogInformation($"{nameof(Startup)} started successfully");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddMvc();

            _appSettingOptions = new AppSettingsOption();
            Configuration.Bind(_appSettingOptions);

            services.Configure<AppSettingsOption>(options =>
            {
                Configuration.Bind(options);
            });
            //services.AddDbContextPool<AllergieDbContext>(
            //    options => options.UseSqlServer(Configuration.GetConnectionString("Default"))
            //    .EnableSensitiveDataLogging());
            services.AddDbContextPool<AllergieDbContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("Default"))
                .EnableSensitiveDataLogging());
            services.AddScoped((IServiceProvider provider) => _logger);
            services.AddScoped<IAllergieDbContext, AllergieDbContext>()
                .AddScoped<IWebServiceInvoker, WebServiceInvoker>()
                .AddScoped<IProductAppService, ProductAppService>()
                .AddScoped<IFoodFactsAppService, FoodFactAppService>()
                .AddScoped<IUserAppService, UserAppService>()
                .AddScoped<INewsAppService, NewsAppService>();
            services.AddTransient<HttpMessageHandler>(x => new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
