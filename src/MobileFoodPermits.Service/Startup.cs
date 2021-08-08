using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MobileFoodPermits.File;
using MobileFoodPermits.File.Models;
using MobileFoodPermits.Models.FoodPermitInfo;
using MobileFoodPermits.Service.Infrastructure;
using MobileFoodPermits.Service.Validators;

namespace MobileFoodPermits.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<ExceptionFilter>()
                .AddControllers(options =>
                {
                    options.Filters.AddService<ExceptionFilter>();
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new CoordinateJsonConverter());
                })
                .AddFluentValidation(fv =>
                    fv
                    .RegisterValidatorsFromAssemblyContaining<FilteredRequestDtoValidator>()
                    .RegisterValidatorsFromAssemblyContaining<ItemValueFilterDtoValidator>()
                );

            var fileSettings = new FileSettings();
            Configuration.GetSection("FileSettings").Bind(fileSettings);

            services.AddFoodPermitFileServices(fileSettings);

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/healthz");
            });
        }
    }
}
