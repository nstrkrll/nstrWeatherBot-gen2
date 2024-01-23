using nstrWeatherBot_gen2.Models;

namespace nstrWeatherBot_gen2.Interfaces
{
    public interface IAuthService
    {
        public Task<string> Login(UserLoginDTO userData);
    }
}
