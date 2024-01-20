using Telegram.Bot.Types;
using Telegram.Bot;

namespace nstrWeatherBot_gen2.Interfaces
{
    public interface ICommand
    {
        public TelegramBotClient Client { get; }

        public string Name { get; }

        public async Task Execute(Update update) { }
    }
}
