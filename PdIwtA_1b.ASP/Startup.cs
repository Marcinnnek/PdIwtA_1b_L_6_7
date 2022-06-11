using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PdIwtA_1b.ASP.Domain;
using PdIwtA_1b.ASP.DTOs.Validators;
using PdIwtA_1b.ASP.Infrastructure;
using PdIwtA_1b.ASP.Middlwares;

namespace PdIwtA_1b.ASP
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
            services.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();
            services.AddSingleton<IUserRepository, UserInMemoryRepository>();

            services
                .AddControllers()
                .AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<AddProductDTOValidator>());
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

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
