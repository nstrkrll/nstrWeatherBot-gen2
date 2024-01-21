using Telegram.Bot.Types;
using Telegram.Bot;
using nstrWeatherBot_gen2.Interfaces;
using nstrWeatherBot_gen2.Services;
using Telegram.Bot.Types.Enums;

namespace nstrWeatherBot_gen2.Commands
{
    public class StartCommand : ICommand
    {
        public TelegramBotClient Client => TelegramBot.GetTelegramBot();

        public string Name => "/start";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            string username = update.Message.Chat.Username;
            await Client.SendTextMessageAsync
                (
                    chatId: chatId,
                    text: $"Привет\\, *\\@{username}*\\!\n" +
                        $"\nЯ погодный бот\\.\n" +
                        $"Отправь мне название населенного пункта\\, прогноз погоды которого хочешь узнать\\.",
                    parseMode: ParseMode.MarkdownV2
                 );
        }
    }
}
