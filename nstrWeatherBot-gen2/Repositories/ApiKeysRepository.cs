using nstrWeatherBot_gen2.Models;
using nstrWeatherBot_gen2.Services;

namespace nstrWeatherBot_gen2.Repositories
{
    public class ApiKeysRepository
    {
        private readonly nstrWeatherDBContext _context;
        private bool _disposed = false;

        public ApiKeysRepository(nstrWeatherDBContext context)
        {
            _context = context;
        }

        public ApiKeys Get(int id)
        {
            return _context.ApiKeys.FirstOrDefault(x => x.ApiKeyId == id);
        }

        public void Update(ApiKeys apiInstance)
        {
            _context.ApiKeys.Update(apiInstance);
            _context.SaveChanges();
            AccuWeather.GetWeatherClient().ApiKey = apiInstance.KeyString;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
