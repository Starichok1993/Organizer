using FluentValidation;
using Hommy.ApiResult;
using Hommy.CQRS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Organizer.Application;
using Organizer.Application.Features.ToDos.Commands;
using Organizer.Infrastructure;
using SimpleInjector;
using System.Text.Json.Serialization;

namespace Organizer.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        private readonly Container _container = new Container();
        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.Converters.Add(new FailureJsonConverter());
                });

            services.AddSwaggerGen();

            services.AddSimpleInjector(_container, options =>
            {
                options.AddAspNetCore().AddControllerActivation();
            });

            services.AddApiResult();

            services.AddCQRS(_container, new[] { typeof(ApplicationLayer).Assembly });

            services.AddDbContext<OrganizerDbContext>(options => 
            {
                options.UseMySql(_configuration["ConnectionStrings:DatabaseConnection"],
                    builder => builder.UseRelationalNulls());
            });

            services.AddScoped<DbContext, OrganizerDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(_container);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                                 
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            _container.Verify(); //Should be last command
        }
    }
}
