using ClientAndServiceSideBlazorSwicting.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace ClientAndServiceSideBlazorSwicting.Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages();
            if (!ClientAndServiceSideBlazorSwicting.Client.Program.IsClientSide)
            {
                services.AddServerSideBlazor();
            }

            services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            if (ClientAndServiceSideBlazorSwicting.Client.Program.IsClientSide)
            {
                app.UseWebAssemblyDebugging();
                app.UseBlazorFrameworkFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                if (!ClientAndServiceSideBlazorSwicting.Client.Program.IsClientSide)
                {
                    endpoints.MapBlazorHub();
                }

                endpoints.MapControllers();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
