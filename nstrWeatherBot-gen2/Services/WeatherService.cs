namespace nstrWeatherBot_gen2.Services
{
    public class WeatherService
    {
        private static AccuWeather _client { get; set; }

        public static AccuWeather GetWeatherClient()
        {
            if (_client != null)
            {
                return _client;
            }

            _client = new AccuWeather("vI0w0LvYwDoXYvrurlRWviCWeB6uySVQ");
            return _client;
        }
    }
}
