using GraphQL.Server;
using GraphQL.Types;
using Graphy.Data;
using Graphy.Schema;
using Graphy.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Graphy
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(o => o.UseInMemoryDatabase("graphy_db"));
            services.AddScoped<CompanySchema>();
            services.AddSingleton<IStockService, StockService>();
            services.AddSingleton<ICompanyService, CompanyService>();
            services.AddSingleton<CompanyType>();
            services.AddSingleton<StockType>();
            services.AddScoped<CompanyQuery>();
            services.AddSingleton<ISchema, CompanySchema>();
            
            //services.AddHttpContextAccessor();
            services.AddGraphQL(o =>
                {
                    o.EnableMetrics = false;
                })
                .AddGraphTypes()
                .AddErrorInfoProvider(opt =>
                {
                    opt.ExposeExceptionStackTrace = true;
                })
                .AddSystemTextJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQL<CompanySchema>();
            app.UseGraphQLWebSockets<CompanySchema>();
            app.UseWebSockets();
            app.UseHttpsRedirection();
            app.UseGraphQLAltair();
        }
    }
}