using System;
using Xunit;
using Vejrudsigten;
using Vejrudsigten.Services;

namespace TestWeatherForecast
{
    public class WeatherForecastTest
    {
        [Theory]
        [InlineData("Kolding", "Regn", 13.6, "Andet", 12.1, "Vejret i Kolding er Regn og der er 13,6 grader. I går var det Andet og 12,1 grader")]
        [InlineData("Nuuk", "Klart vejr", 1.3, "Klart vejr", 3.2, "Klart vejr igen i Nuuk med 1,3 grader idag og i går 3,2 grader")]
        [InlineData("Oslo", "Skyet", 11, "Sne", -1.2, "Slut med Sne vejr og -1,2 grader. Nu bliver det Skyet og 11 grader i Oslo")]
        [InlineData("Moskva", "Sne", 2.3, "Regn", 2.8, "Kælke tid i Moskva i Sne vejr med 2,3 grader. I går var det Regn med 2,8 grader")]
        [InlineData("Stockholm", "Andet", 11, "Skyet", 1.2, "Det samme Andet vejr i Stockholm med 11 grader. I går var det Skyet med 1,2 grader")]
        [InlineData("Oslo", "Andet", 11, "Andet", 1.2, "Ikke så meget at sige. Andet vejr igår og igen idag med temperatur på 11 i Oslo")]
        [InlineData("Dubai", "Klart vejr", 30.6, "Andet", 29.8, "Juhuu Klart vejr i Dubai med 30,6 grader. I går var det Andet kedeligt med 29,8 grader")]
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
