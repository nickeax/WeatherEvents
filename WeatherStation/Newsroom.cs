using Entities.Models;

public class Newsroom
{
    public void HandleHighTempBroadcast(Object sender, WeatherReportArgs args)
    {
        Console.WriteLine($"TEMP WARNING! \n{args.WeatherItem.Display()}\n\n");
    }

    public void HandleHighWindBroadcast(Object sender, WeatherReportArgs args)
    {
        Console.WriteLine($"WIND WARNING! \n{args.WeatherItem.Display()}\n\n");
    }
}