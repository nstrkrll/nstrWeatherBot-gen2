using nstrWeatherBot_gen2.Models;

namespace nstrWeatherBot_gen2
{
    public class WeatherForecast
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }

    public class Day
    {
        public string IconPhrase { get; set; }
    }
    public class Night
    {
        public string IconPhrase { get; set; }
    }
}
