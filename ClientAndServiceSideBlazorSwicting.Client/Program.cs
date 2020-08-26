using System;
using System.Net.Http;
using System.Threading.Tasks;
using ClientAndServiceSideBlazorSwicting.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ClientAndServiceSideBlazorSwicting.Client
{
    public class Program
    {
        public static readonly bool IsClientSide = false;

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddSingleton<IWeatherForecastService, HttpWeatherForecastService>();
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });

            await builder.Build().RunAsync();
        }
    }
}
