
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day5 : ISolver
{
    public (string, string) ExpectedResult => ("1181555926", "");


    public (string, string) Solve(string[] input)
    {
        var seeds = Regex.Matches(input[0],@"(\d+)").Select(n => long.Parse(n.Value)).ToArray();

        // will assume in order input
        var conversions = new List<List<(long dest, long source, long length)>>();
        List<(long dest, long source, long length)>? current = null;
        foreach (var line in input.Skip(2).Where(l => l.Length > 0))
        {
            if (char.IsLetter(line[0]))
            {
                current = new List<(long dest, long source, long length)>();
                conversions.Add(current);
            }
            else
            {
                var match = Regex.Match(line, @"(\d+) (\d+) (\d+)");
                current!.Add((long.Parse(match.Groups[1].Value), long.Parse(match.Groups[2].Value), long.Parse(match.Groups[3].Value)));
            }
        }
        var lowest = long.MaxValue;
        foreach (var seed in seeds)
        {
            var currentPlace = seed;
            foreach(var conversion in conversions)
            {
                bool match = false;
                foreach(var (dest, source, length) in conversion)
                {
                    if (currentPlace >= source && currentPlace < source+length)
                    {
                        currentPlace = dest + currentPlace - source;
                        match = true;
                        break;
                    }
                }
                if (!match)
                {
                    // non-matching means we stay in same place
                }
            }
            lowest = Math.Min(lowest, currentPlace);
        }

        return (lowest.ToString(), "");
    }
}
