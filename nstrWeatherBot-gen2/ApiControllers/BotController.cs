using Microsoft.AspNetCore.Mvc;
using nstrWeatherBot_gen2.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace nstrWeatherBot_gen2.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : Controller
    {
        private TelegramBotClient _bot;
        private TelegramBotUpdateDistributor<TelegramBotCommandExecutor> _updateDistributor;

        public BotController()
        {
            _bot = TelegramBot.GetTelegramBot();
            _updateDistributor = new TelegramBotUpdateDistributor<TelegramBotCommandExecutor>();
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
