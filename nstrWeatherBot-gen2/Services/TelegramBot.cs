using Telegram.Bot;

namespace nstrWeatherBot_gen2.Services
{
    public class TelegramBot
    {
        private static TelegramBotClient _client { get; set; }

        public static TelegramBotClient GetTelegramBot()
        {
            if (_client != null)
            {
                return _client;
            }

            _client = new TelegramBotClient("5027490030:AAGl_P-FAG3_v-SiaexZP9b7cjSbVlgE2OA");
            return _client;
        }
    }
}
