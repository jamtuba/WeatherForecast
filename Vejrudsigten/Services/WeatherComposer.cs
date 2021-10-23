using System;
using System.Collections.Generic;
using System.Text;

namespace Vejrudsigten.Services
{
    public class WeatherComposer
    {
        readonly List<string> WeatherTypesFromDescription = new()
        {
            "Sol og blaa himmel",
            "Regn, regn og atter regn",
            "Sne saa langt oejet raekker",
            "Graat og kedeligt",
            "Omskifteligt vejr"
        };
        readonly List<string> WeatherTypesFromDegrees = new()
        {
            " og det er meget koldt. Bliv hjemme!",
            " og du skal have ski eller skoejter med!",
            ", men stadig ikke super varmt.",
            ", husk solcremen.",
            " og saa varmt at du skal blive i skyggen."
        };

        public string GetSpecialWeatherForecast(WeatherInfo yesterday, WeatherInfo today)
        {
            var result = new StringBuilder();

            var yesterdayWeatherType = yesterday.Conditions;
            var yesterdayTemperature = yesterday.Temperature;

            var todayWeatherType = today.Conditions;
            var todaydayTemperature = today.Temperature;

            if (todaydayTemperature != yesterdayTemperature || yesterdayWeatherType != todayWeatherType)
            {
                result.Append("Vejret skifter! ");
            }

            GetTheWeatherType(todayWeatherType, result);

            GetTheTemperature(todaydayTemperature, result);
            
            return result.ToString();
        }

        public void GetTheWeatherType(string todayWeatherType, StringBuilder result)
        {
            switch (todayWeatherType)
            {
                case "Klart vejr":
                    result.Append(WeatherTypesFromDescription[0]);
                    break;
                case "Regn":
                    result.Append(WeatherTypesFromDescription[1]);
                    break;
                case "Sne":
                    result.Append(WeatherTypesFromDescription[2]);
                    break;
                case "Skyet":
                    result.Append(WeatherTypesFromDescription[3]);
                    break;
                default:
                    result.Append(WeatherTypesFromDescription[4]);
                    break;
            }
        }

        public void GetTheTemperature(double todaydayTemperature, StringBuilder result)
        {
            if (todaydayTemperature < -10)
                result.Append(WeatherTypesFromDegrees[0]);
            else if (todaydayTemperature < 0)
                result.Append(WeatherTypesFromDegrees[1]);
            else if (todaydayTemperature < 15)
                result.Append(WeatherTypesFromDegrees[2]);
            else if (todaydayTemperature < 30)
                result.Append(WeatherTypesFromDegrees[3]);
            else
                result.Append(WeatherTypesFromDegrees[4]);
        }

    }
}
