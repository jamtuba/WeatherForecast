using System.Text;
using Vejrudsigten.Services;
using Xunit;

namespace Vejrudsigten.Test
{
    public class WeatherTest
    {
        [Theory]
         [InlineData("Klart vejr", "Masser af sol og blå himmel")]
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
        [InlineData("Dårligt vejr")]
        public void Test_GetTheWeatherType_Throws_No_Exception(string todayWeatherType)
        {
            // Arrange
            var sut = new WeatherComposer();
            var strBuilder = new StringBuilder();

            // Act
            var exception = Record.Exception(() =>  sut.GetTheWeatherType(todayWeatherType, strBuilder));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(-10, " og du skal have ski eller skøjter med!")]
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
    }
}
