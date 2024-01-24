using Microsoft.AspNetCore.Mvc;
using nstrWeatherBot_gen2.Repositories;
using nstrWeatherBot_gen2.Services;
using Telegram.Bot.Types;

namespace nstrWeatherBot_gen2.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : Controller
    {
        private TelegramBotUpdateDistributor<TelegramBotCommandExecutor> _updateDistributor;

        public BotController(ApiKeysRepository repository)
        {
            _updateDistributor = new TelegramBotUpdateDistributor<TelegramBotCommandExecutor>();
            var weatherService = AccuWeather.GetWeatherClient();
            if (string.IsNullOrEmpty(weatherService.ApiKey))
            {
                weatherService.ApiKey = repository.Get(1).KeyString;
            }
        }

        [HttpPost]
        public async void Post(Update update)
        {
            if (update.Message == null)
            {
                return;
            }

            await _updateDistributor.GetUpdate(update);
        }
    }
}
