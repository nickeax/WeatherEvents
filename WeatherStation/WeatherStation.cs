using Entities.Models;
namespace Modules;
/// <summary>
/// Publishes weather data where temperatures are over 35DEG C wind speeds higher than 20KMh
/// </summary>
public class WeatherStation
{
    Random _rnd = new();
    string[] _directions = "N|E|S|W|NE|NW|SE|SW".Split('|');
    // Weather Reading Range
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime End { get; set; } = DateTime.Now.AddMonths(2);
    /// <summary>Will maintain a list as a type of log, but will send individual items to subscribers</summary>
    public List<WeatherItem> WeatherItems { get; set; } = new();

    public EventHandler<WeatherReportArgs> StrongWindEvent;
    public EventHandler<WeatherReportArgs> HighTemperatureEvent;

    public WeatherStation()
    {
        GenerateWeatherData();
    }

    void GenerateWeatherData()
    {
        DateTime curr = Start;

        while (curr <= End)
        {
            WeatherItems.Add(GenerateWeatherItem(curr));

            curr = curr.AddDays(1);
        }
    }

    public void SimulateWeatherTracking()
    {
        foreach (var item in WeatherItems)
        {
            Thread.Sleep(3000);

            if (item.Temperature >= 35)
                OnHighTemperature(new WeatherReportArgs { WeatherItem = item });

            if (item.Wind.WindSpeed >= 25)
                OnStrongWind(new WeatherReportArgs { WeatherItem = item });
        }
    }

    public void OnStrongWind(WeatherReportArgs e)
    {
        StrongWindEvent?.Invoke(this, e);
    }

    public void OnHighTemperature(WeatherReportArgs e)
    {
        HighTemperatureEvent?.Invoke(this, e);
    }

    public WeatherItem GenerateWeatherItem(DateTime dt)
    {
        return new WeatherItem
        {
            Recorded = dt,
            Temperature = GetTemperature(),
            Wind = new WindItem { WindSpeed = GetWindSpeed(), Direction = GetDirection() }
        };
    }

    // Generate Weather Metrics
    int GetWindSpeed()
    {
        return (int)_rnd.NextInt64(0, 200);
    }

    string GetDirection()
    {
        return _directions[_rnd.Next(_directions.Length - 1)];
    }

    int GetTemperature()
    {
        return _rnd.Next(-40, 60);
    }
}