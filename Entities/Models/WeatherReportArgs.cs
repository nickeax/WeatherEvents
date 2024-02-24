namespace Entities.Models;

public class WeatherReportArgs : EventArgs
{
    public WeatherItem WeatherItem { get; set; } = new();
}
