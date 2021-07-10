using System;
using BGScreener.DbModels;
using BGScreener.Logger;
using BGScreener.Services;
using BGScreener.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BGScreener
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<BGScreenerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IBoardgameService, BoardgameService>();
            services.AddTransient<IHistoricalPriceService, HistoricalPriceService>();
            services.AddTransient<IExchangeRateService, ExchangeRateService>();

            services.AddSingleton<ILogger, ConsoleLogger>();

            services.AddControllers().AddNewtonsoftJson(op =>
                op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddControllers(op => op.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<BGScreenerContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    serviceScope.ServiceProvider.GetService<BGScreenerContext>().EnsureSeedData();
                }
            }

            if (env.IsProduction())
            {
                //Todo: Create migration
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<BGScreenerContext>().Database.EnsureCreated();
                    serviceScope.ServiceProvider.GetService<BGScreenerContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<BGScreenerContext>().EnsureSeedData();
                }
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc();
        }
    }
}
