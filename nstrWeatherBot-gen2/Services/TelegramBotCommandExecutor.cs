using nstrWeatherBot_gen2.Commands;
using nstrWeatherBot_gen2.Interfaces;
using Telegram.Bot.Types;

namespace nstrWeatherBot_gen2.Services
{
    public class TelegramBotCommandExecutor : ITelegramUpdateListener
    {
        private List<ICommand> _commands;

        public TelegramBotCommandExecutor()
        {
            _commands = new List<ICommand>()
            {
                new StartCommand()
            };
        }

        public async Task GetUpdate(Update update)
        {
            Message message = update.Message;
            if (message.Text == null)
            {
                return;
            }

            foreach (var command in _commands)
            {
                if (command.Name.Equals(message.Text.Trim()))
                {
                    await command.Execute(update);
                }
            }
        }
    }
}
