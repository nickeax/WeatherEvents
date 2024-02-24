namespace Entities.Models;
public class WeatherItem
{
    public DateTime Recorded { get; set; }
    public int Temperature { get; set; }
    public WindItem Wind { get; set; }

    public string Display()
    {
        return string.Format("{0,-30}{1,4}°C{2,15}KMh{3,4}", Recorded, Temperature, Wind.WindSpeed, Wind.Direction);
    }
}