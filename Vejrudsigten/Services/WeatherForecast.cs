using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vejrudsigten.Services
{
    public static class WeatherForecast
    {
        private static readonly String klartVejr = "Klart vejr";
        private static readonly String regn = "Regn";
        private static readonly String skyet = "Skyet";
        private static readonly String sne = "Sne";
        private static readonly String andet = "Andet";

        public static async Task<string> GetForecastAsync(string key)
        {
            //String town = "Dubai"; // Vejret i Dubai er Klart vejr og der er 30 grader. I går var det Andet og 31,5 grader
            //String town = "Koege"; // Vejret i Koege er Regn og der er 14,1 grader. I går var det Andet og 11,5 grader
            //String town = "Nuuk"; // Vejret i Nuuk er Klart vejr og der er 1,3 grader. I går var det Klart vejr og 3,2 grader
            //String town = "Moskva"; // Vejret i Moskva er Sne og der er 2,3 grader. I går var det Andet og 2,8 grader
            String town = "Oslo"; // Vejret i Oslo er Andet og der er 11 grader. I går var det Andet og 1,2 grader
            WeatherService service = new WeatherService();
            var todayInfo = await service.GetTodaysWeather(key, town);
            var yesterdayInfo = await service.GetYesterdaysWeather(key, town);

            return GetWeatherMessageBasedOnInput(town, 
                todayInfo.Conditions, todayInfo.Temperature, yesterdayInfo.Conditions, yesterdayInfo.Temperature);
        }

        public static String GetWeatherMessageBasedOnInput(String town, String todaysConditions, double todaysTemperature, 
            String yesterdayCondition, double yesterdayTemperature)
        {
            String result = "";
            
            if (todaysConditions.Contains(klartVejr) && yesterdayCondition.Contains(klartVejr))
            {
                result = "{0} igen i {1} med {2} grader idag og i går {3} grader";
                return String.Format(result, todaysConditions, town, todaysTemperature, yesterdayTemperature);
            }

            if (todaysConditions.Contains(klartVejr))
            {
                result = "Juhuu {0} i {1} med 30,6 grader. I går var det {2} kedeligt med {3} grader";
                return String.Format(result, todaysConditions, town, yesterdayCondition, yesterdayTemperature);
            }

            if (todaysConditions.Contains(sne))
            {
                result = "Kælke tid i {0} i {1} vejr med {2} grader. I går var det {3} med {4} grader";
                return String.Format(result, town, todaysConditions, todaysTemperature, yesterdayCondition, yesterdayTemperature);
            }

            if (todaysConditions.Contains(regn))
            {
                result = "Vejret i " + town + " er {0} og der er {1} grader. I går var det {2} og {3} grader";
                return String.Format(result, todaysConditions, todaysTemperature, yesterdayCondition, yesterdayTemperature);
            }

            if (todaysConditions.Contains(skyet))
            {
                result = "Slut med {0} vejr og {1} grader. Nu bliver det {2} og {3} grader i {4}";
                return String.Format(result, yesterdayCondition, yesterdayTemperature, todaysConditions, todaysTemperature, town);
            }

            if (todaysConditions.Contains(andet) && yesterdayCondition.Contains(andet))
            {
                result = "Ikke så meget at sige. {0} vejr igår og igen idag med temperatur på {1} i {2}";
                return String.Format(result, todaysConditions, todaysTemperature, town);
            }

            if (todaysConditions.Contains(andet))
            {
                result = "Det samme {0} vejr i {1} med {2} grader. I går var det {3} med {4} grader";
                return String.Format(result, todaysConditions, town, todaysTemperature, yesterdayCondition, yesterdayTemperature);
            }

            result = "Ukendt vejr type i {0} er {1} og der er {2} grader. I går var det {3} og {4} grader";
            return String.Format(result, town, todaysConditions, todaysTemperature, yesterdayCondition, yesterdayTemperature);
        }
    }
}
