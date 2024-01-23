using System.ComponentModel.DataAnnotations;

namespace nstrWeatherBot_gen2.Models
{
    public class User
    {
        [Key]
        public int? UserId { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
