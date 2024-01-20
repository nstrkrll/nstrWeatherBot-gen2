using nstrWeatherBot_gen2.Services;
using Telegram.Bot.Types;
using Telegram.Bot;
using nstrWeatherBot_gen2.Interfaces;

namespace nstrWeatherBot_gen2.Commands
{
    public class WeatherCommand : ICommand
    {
        public TelegramBotClient Client => TelegramBot.GetTelegramBot();

        public string Name => "";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            await Client.SendTextMessageAsync
            (
                chatId: chatId,
                text: WeatherService.GetWeatherClient().GetWeatherInfo(update.Message.Text)
            );
        }
    }
}
