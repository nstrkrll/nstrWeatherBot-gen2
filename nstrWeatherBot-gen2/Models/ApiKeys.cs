using System.ComponentModel.DataAnnotations;

namespace nstrWeatherBot_gen2.Models
{
    public class ApiKeys
    {
        [Key]
        public int? ApiKeyId { get; set; }
        public string KeyString { get; set; }
    }
}
