using Modules;

var WS = new WeatherStation();
var newsRoom = new Newsroom();

WS.HighTemperatureEvent += newsRoom.HandleHighTempBroadcast;
WS.StrongWindEvent += newsRoom.HandleHighWindBroadcast;

WS.SimulateWeatherTracking();