using System;
using System.Threading.Tasks;

namespace Vejrudsigten.Services
{
    public static class WeatherForecast
    {
        public static async Task<string> GetForecastAsync(string key, string city)
        {
            WeatherService service = new WeatherService();
            var todayInfo = await service.GetTodaysWeather(key, city);
            var yesterdayInfo = await service.GetYesterdaysWeather(key, city);

            var weatherComposer = new WeatherComposer();

            return weatherComposer.GetSpecialWeatherForecast(todayInfo, yesterdayInfo);
        }
    }
}
