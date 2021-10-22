using System.Text;
using Vejrudsigten.Services;
using Xunit;

namespace Vejrudsigten.Test
{
    public class WeatherTest
    {
        [Theory]
        [InlineData("Sne", -10.00, "Klart vejr", -10.01, "Vejret skifter! Masser af sol og blaa himmel og det er meget koldt. Bliv hjemme!")]
        [InlineData("Sne", -10.00, "Sne", -10.00, "Masser af sne og du skal have ski eller skoejter med!")]
        [InlineData("Klart vejr", 0.00, "Regn", 0.01, "Vejret skifter! Regn, regn og atter regn, men stadig ikke super varmt.")]
        [InlineData("Skyet", 15.00, "Skyet", 15.00, "Graat og kedeligt, husk solcremen.")]
        [InlineData("Klart vejr", 30.00, "Andet", 30.00, "Vejret skifter! Kedeligt og omskifteligt vejr og saa varmt at du skal blive i skyggen.")]
        public void Test_GetSpecialWeatherForecast_Returns_Correct_String(string yesterdayWeatherType, double yesterdayTemperature, string todayWeatherType, double todayTemperature, string expectedString)
        {
            // Arrange
            var sut = new WeatherComposer();
            var strBuilder = new StringBuilder();
            var yesterWeather = new WeatherInfo() { Conditions = yesterdayWeatherType, Temperature = yesterdayTemperature };
            var todayWeather = new WeatherInfo() { Conditions = todayWeatherType, Temperature = todayTemperature };

            // Act
            strBuilder.Append(sut.GetSpecialWeatherForecast(yesterWeather, todayWeather));

            // Assert
            Assert.Equal(expectedString, strBuilder.ToString());
        }

        [Theory]
        [InlineData("Sne", -10.00, "Klart vejr", -10.01)]
        [InlineData("Sol", -10.00, "Sne", -10.00)]
        [InlineData("", -10.00, "Sne", -10.00)]
        [InlineData("Sne", null, "Sne", -10.00)]
        [InlineData("Sne", 0, "Sne", -10.00)]

        public void Test_GetSpecialWeatherForecast_Throws_No_Exception(string yesterdayWeatherType, double yesterdayTemperature, string todayWeatherType, double todayTemperature)
        {
            // Arrange
            var sut = new WeatherComposer();
            var strBuilder = new StringBuilder();
            var yesterWeather = new WeatherInfo() { Conditions = yesterdayWeatherType, Temperature = yesterdayTemperature };
            var todayWeather = new WeatherInfo() { Conditions = todayWeatherType, Temperature = todayTemperature };

            // Act
            var exception = Record.Exception(() => sut.GetSpecialWeatherForecast(yesterWeather, todayWeather));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("Klart vejr", "Masser af sol og blaa himmel")]
        public void Test_GetTheWeatherType_Appends_To_Stringbuilder(string todayWeatherType, string expectedString)
        {
            // Arrange
            var sut = new WeatherComposer();
            var strBuilder = new StringBuilder();

            // Act
            sut.GetTheWeatherType(todayWeatherType, strBuilder);

            // Assert
            Assert.Equal(expectedString, strBuilder.ToString());
        }

        [Theory]
        [InlineData("Klart vejr")]
        [InlineData("Daarligt vejr")]
        [InlineData("")]
        public void Test_GetTheWeatherType_Throws_No_Exception(string todayWeatherType)
        {
            // Arrange
            var sut = new WeatherComposer();
            var strBuilder = new StringBuilder();

            // Act
            var exception = Record.Exception(() => sut.GetTheWeatherType(todayWeatherType, strBuilder));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(-10, " og du skal have ski eller skoejter med!")]
        public void Test_GetTheTemperature_Appends_To_Stringbuilder(double todaydayTemperature, string expectedString)
        {
            // Arrange
            var sut = new WeatherComposer();
            var strBuilder = new StringBuilder();

            // Act
            sut.GetTheTemperature(todaydayTemperature, strBuilder);

            // Assert
            Assert.Equal(expectedString, strBuilder.ToString());
        }

        [Theory]
        [InlineData(-10.00)]
        [InlineData(101.00)]
        [InlineData(null)]
        public void Test_GetTheTemperature_Throws_No_Exception(double todaydayTemperature)
        {
            // Arrange
            var sut = new WeatherComposer();
            var strBuilder = new StringBuilder();

            // Act
            var exception = Record.Exception(() => sut.GetTheTemperature(todaydayTemperature, strBuilder));

            // Assert
            Assert.Null(exception);
        }
    }
}
