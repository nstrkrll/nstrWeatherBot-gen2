using nstrWeatherBot_gen2.Interfaces;
using Telegram.Bot.Types;

namespace nstrWeatherBot_gen2.Services
{
    public class TelegramBotUpdateDistributor<T> where T : ITelegramUpdateListener, new()
    {
        private Dictionary<long, T> _listeners;

        public TelegramBotUpdateDistributor()
        {
            _listeners = new Dictionary<long, T>();
        }

        public async Task GetUpdate(Update update)
        {
            long chatId = update.Message.Chat.Id;
            T? listener = _listeners.GetValueOrDefault(chatId);
            if (listener is null)
            {        
                listener = new T();
                _listeners.Add(chatId, listener);
                await listener.GetUpdate(update);
                return;
            }

            await listener.GetUpdate(update);
        }
    }
}
