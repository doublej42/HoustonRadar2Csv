using HoustonRadar2Csv;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

using IHost host = Host
    .CreateDefaultBuilder(args)
    .Build();
//Get Filename from console
var filename = Path.GetFullPath(args[0]);
Console.WriteLine($"Reading {filename}");
Console.WriteLine("What the Study ID?");
var study = Console.ReadLine();
using var inFile = File.OpenText(filename);
var lineRegex = new Regex(@"^Time = (?<time>\d+), Type = \d+, (?<data>.*)$");
var line = inFile.ReadLine();
var output = new OutputCSV();

var dataRegex = new Regex(@"^Tgz\(dir,class,time\(s\),speed\(mph\)\) = (?<vehicle>\([^\)]*\) ?)*$");
var vehicleRegex = new Regex(@"\((?<dir>[0,1]),(?<class>\d),(?<time>-?\d+),(?<speed>\d+)\)");
while(line != null)
{
    var match = lineRegex.Match(line);
    var when = DateTimeOffset.FromUnixTimeSeconds(long.Parse(match.Groups["time"].Value)).LocalDateTime;
    var data = match.Groups["data"].Value;
    var dataMatch = dataRegex.Match(data);
    if (dataMatch.Success)
    {
        
        foreach(var vehicle in dataMatch.Groups["vehicle"].Captures.Select(c => c.Value))
        {
            var vehicleMatch = vehicleRegex.Match(vehicle);
            output.Data.Add(new TrafficDataPoint
            {
                Direction = vehicleMatch.Groups["dir"].Value,
                Class = vehicleMatch.Groups["class"].Value,
                Time = when.AddSeconds(int.Parse(vehicleMatch.Groups["time"].Value)).ToString(@"yyyy-MM-ddTHH:mm:ss"),
                Speed = vehicleMatch.Groups["speed"].Value,
            });
        }
    }
    line = inFile.ReadLine();
}
Console.WriteLine($"Writing {output.Data.Count} datapoints to {study}.csv");
output.WriteFile($"{study}.csv");

//host.Run();
//await host.RunAsync();


