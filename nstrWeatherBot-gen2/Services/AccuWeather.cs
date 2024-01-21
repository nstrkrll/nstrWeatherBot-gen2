using nstrWeatherBot_gen2.Models.AccuWeather;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace nstrWeatherBot_gen2.Services
{
    public class AccuWeather
    {
        private string _apiKey;
        private HttpClient _httpClient;

        public AccuWeather(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
        }

        public string GetWeatherInfo(string CityName)
        {
            try
            {
                var cityQueryUrl = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={_apiKey}&q={CityName}&language=ru-ru";
                string cityJson = Task.Run(() => _httpClient.GetStringAsync(cityQueryUrl)).Result;
                var city = JsonSerializer.Deserialize<ObservableCollection<City>>(cityJson);
                var weatherForecastQueryUrl = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{city[0].Key}?apikey={_apiKey}&language=ru-ru&metric=true";
                string weatherForecastJson = Task.Run(() => _httpClient.GetStringAsync(weatherForecastQueryUrl)).Result;
                var weatherforecast = JsonSerializer.Deserialize<WeatherForecast>(weatherForecastJson);
                return GetResultString(city, weatherforecast);
            }
            catch (ArgumentOutOfRangeException)
            {
                return "Похоже такого населенного пункта не существует...";
            }
            catch (Exception ex)
            {
                return "Не удалось отобразить погоду в запрашиваемой точке.\nОбратитесь к администратору: @nstrkrll";
            }
        }

        private string GetResultString(ObservableCollection<City> city, WeatherForecast forecast)
        {
            var cityPattern = 
                "📍 {0}, {1}\n" +
                "Административный центр: {2}\n";
            var weatherForecastPattern = 
                "☀️ Днем:\n" +
                "{0} °C, {1}\n\n" +
                "🌙 Ночью: \n" +
                "{2} °C, {3}\n" +
                "\nДанные предоставлены:\n" +
                "☀️AccuWeather";
            return 
                string.Format
                (
                    cityPattern, 
                    city[0].LocalizedName, 
                    city[0].Country.LocalizedName, 
                    city[0].AdministrativeArea.LocalizedName
                ) +
                string.Format
                (
                    weatherForecastPattern,
                    forecast.DailyForecasts[0].Temperature.Maximum.Value, 
                    forecast.DailyForecasts[0].Day.IconPhrase,
                    forecast.DailyForecasts[0].Temperature.Minimum.Value, 
                    forecast.DailyForecasts[0].Night.IconPhrase
                );
        }
    }
}