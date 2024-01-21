using nstrWeatherBot_gen2.Commands;
using nstrWeatherBot_gen2.Interfaces;
using Telegram.Bot.Types;

namespace nstrWeatherBot_gen2.Services
{
    public class TelegramBotCommandExecutor : ITelegramUpdateListener
    {
        private List<ICommand> _commonCommands;
        private WeatherCommand _weatherCommand;

        public TelegramBotCommandExecutor()
        {
            _commonCommands = new List<ICommand>()
            {
                new StartCommand(),
                new HelpCommand(),
            };

            _weatherCommand = new WeatherCommand();
        }

        public async Task GetUpdate(Update update)
        {
            var message = update.Message;
            if (message.Text == null)
            {
                return;
            }

            foreach (var command in _commonCommands)
            {
                if (command.Name.Equals(message.Text.Trim()))
                {
                    await command.Execute(update);
                    return;
                }
            }

            await _weatherCommand.Execute(update);
        }
    }
}
