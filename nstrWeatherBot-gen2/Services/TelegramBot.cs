using Telegram.Bot;

namespace nstrWeatherBot_gen2.Services
{
    public class TelegramBot
    {
        private static TelegramBotClient _client;
        private static object _lock = new object();

        public static TelegramBotClient GetTelegramBot()
        {
            lock (_lock)
            {
                if (_client == null)
                {
                    _client = new TelegramBotClient("5027490030:AAFo2kbzOnYcYo9N83KiQUhl5E7wTAv5asg");
                }

                return _client;
            }
        }
    }
}
