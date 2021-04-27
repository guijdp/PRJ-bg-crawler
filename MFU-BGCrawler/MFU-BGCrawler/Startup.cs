using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Logger;
using MFU_BGCrawler.Services;
using MFU_BGCrawler.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MFU_BGCrawler
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IBoardgameService, BoardgameService>();
            services.AddTransient<IHistoricalPriceService, HistoricalPriceService>();
            services.AddTransient<IExchangeRateService, ExchangeRateService>();

            services.AddSingleton<BGSniperContext>();
            services.AddSingleton<ILogger, ConsoleLogger>();

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

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

            app.UseMvc();
        }
    }
}
