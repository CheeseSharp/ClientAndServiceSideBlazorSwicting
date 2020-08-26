namespace ClientAndServiceSideBlazorSwicting.Client
{
    using ClientAndServiceSideBlazorSwicting.Shared;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net.Http.Json;

    public class HttpWeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public HttpWeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<IEnumerable<WeatherForecast>> GetForecastAsync(DateTime startDate)
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
        }
    }
}
