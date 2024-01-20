namespace nstrWeatherBot_gen2.Models.AccuWeather
{
    public class City
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public Country Country { get; set; }
        public AdministrativeArea AdministrativeArea { get; set; }
    }
}
