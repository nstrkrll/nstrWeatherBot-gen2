using Telegram.Bot.Types;

namespace nstrWeatherBot_gen2.Interfaces
{
    public interface ITelegramUpdateListener
    {
        public async Task GetUpdate(Update update) { }
    }
}
