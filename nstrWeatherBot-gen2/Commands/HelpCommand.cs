using nstrWeatherBot_gen2.Services;
using Telegram.Bot.Types;
using Telegram.Bot;
using nstrWeatherBot_gen2.Interfaces;
using Telegram.Bot.Types.Enums;

namespace nstrWeatherBot_gen2.Commands
{
    public class HelpCommand : ICommand
    {
        public TelegramBotClient Client => TelegramBot.GetTelegramBot();

        public string Name => "/help";

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            await Client.SendTextMessageAsync
            (
                chatId: chatId, 
                text: $"Я \\- погодный бот\\!\n" +
                    $"\nНапиши название населенного пункта\\, прогноз погоды которого хочешь узнать\\." +
                    $"\nДля уточнения можешь указать страну или административный центр\\, в которых находится нужный населенный пункт\\.\n" +
                    $"\n*Подойдет такой формат\\:*\n" +
                    $"*_Витебск_*\n" +
                    $"или\n" +
                    $"*_Витебск, Беларусь_*\n" +
                    $"или\n" +
                    $"*_Витебск Россия Новосибирск_*", 
                parseMode: ParseMode.MarkdownV2
            );
        }
    }
}
