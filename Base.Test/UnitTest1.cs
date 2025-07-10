using Base;
using Xunit;

namespace Base.Test;

public class UnitTest1
{

    [Fact]
    public async Task GetWeatherForecast()
    {
        // Arrange
        Controllers.WeatherForecastController service = new Controllers.WeatherForecastController();

        //act
        IEnumerable<WeatherForecast> actualGetTempData = service.Get();

        //assert
        Assert.NotNull(actualGetTempData);

        var enumerator = actualGetTempData.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Nullable<int> tempC = enumerator.Current.TemperatureC;
            Assert.NotNull(tempC);
            Assert.Equal(tempC, 20);
        }
    }

}
