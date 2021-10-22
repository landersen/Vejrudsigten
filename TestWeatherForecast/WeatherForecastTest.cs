using System;
using Xunit;
using Vejrudsigten;
using Vejrudsigten.Services;

namespace TestWeatherForecast
{
    public class WeatherForecastTest
    {
        [Theory]
        [InlineData("Kolding", "Sne", -6, "Regn", 3.6, "Det bliver koldt med -6 grader og der kommer Sne vejr i Kolding. I går var det Regn og 3,6 grader")]
        [InlineData("Nuuk", "Regn", 1.3, "Skyet", 3.2, "Nu kommer der Regn i Nuuk med 1,3 grader idag og i går var det Skyet med 3,2 grader")]
        [InlineData("Stockholm", "Skyet", 11, "Klart vejr", 1.2, "Skyet vejr i Stockholm med 11 grader. I går var det Klart vejr og 1,2 grader")]
        [InlineData("Oslo", "Skyet", 11, "Sne", -1.2, "Slut med Sne vejr og -1,2 grader. Nu bliver det Skyet og 11 grader i Oslo")]
        [InlineData("Moskva", "Klart vejr", 2.3, "Sne", -2.8, "Kælk og Sne vejr med -2,8 er forbi. Nu bliver det flot Klart vejr med 2,3 i Moskva")]
        [InlineData("Oslo", "Andet", 11, "Andet", 1.2, "Ikke så meget at sige. Andet vejr igår og igen idag med temperatur på 11 i Oslo")]
        [InlineData("Dubai", "Klart vejr", 30.6, "Andet", 29.8, "Flot Klart vejr i Dubai med 30,6 grader. I går var det Andet med 29,8 grader")]
        [InlineData("Andeby", "Fjolle vejr", 0, "Andet fjollede vejr", 0, "Ukendt vejr type i Andeby er Fjolle vejr og der er 0 grader. I går var det Andet fjollede vejr og 0 grader")]
        public void Test_weather_message_based_on_input(String town, String todaysConditions, double todaysTemperature,
            String yesterdayCondition, double yesterdayTemperature, String expected)
        {
            String result = WeatherForecast.GetWeatherMessageBasedOnInput(town, todaysConditions, todaysTemperature,
                yesterdayCondition, yesterdayTemperature);
            Assert.Equal(expected,result);
        }
    }
}
