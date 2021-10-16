using System;
using System.Threading.Tasks;

namespace Vejrudsigten.Services
{
    public static class WeatherForecast
    {
        public static async Task<string> GetForecastAsync(string key)
        {
            WeatherService service = new WeatherService();
            var todayInfo = await service.GetTodaysWeather(key, "Aarhus");
            var yesterdayInfo = await service.GetYesterdaysWeather(key, "Aarhus");

            String result = "Vejret i Århus er {0} og der er {1} grader. I går var det {2} og {3} grader";
            return String.Format(result, todayInfo.Conditions, todayInfo.Temperature, yesterdayInfo.Conditions, yesterdayInfo.Temperature);
        }
    }
}
