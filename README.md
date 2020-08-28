# ClientAndServiceSideBlazorSwicting
This project demos how Client and Server can be switched with .Net 3.1 and Blazor 3.2.1.
Thre project is based on Daniel Roth [danroth27](https://github.com/danroth27) [BlazorWebAssemblyWithPrerendering](https://github.com/danroth27/BlazorWebAssemblyWithPrerendering) project.

The reason for put this together was the lack of information regarding being able to switch between client and server, the default templates assumes one or other mode being used.

The demo is a simple example of how to switch between server and client modes, witch modules and services need to switched and when, and it is not an example of production ready code. 

##### ClientAndServiceSideBlazorSwicting.Client.Program.cs

`public static readonly bool IsClientSide = false;` allows for changing between client and server mode.

```csharp
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
```

The `.csproj` files show the required modules and in which project for the switching to be easily configured. 




