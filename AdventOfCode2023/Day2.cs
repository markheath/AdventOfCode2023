using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day2 : ISolver
{
    public (string, string) ExpectedResult => ("2528", "67363");

    public (string, string) Solve(string[] input)
    {
        var part1 = 0;
        var part2 = 0;
        foreach(var game in input)
        {
            var gameNumber = int.Parse(Regex.Match(game, @"Game (\d+)").Groups[1].Value);
            var max = Regex.Matches(game, @"(\d+) (\w+)")
                 .ToDictionaryWithCombiner(m => m.Groups[2].Value,
                    m => int.Parse(m.Groups[1].Value), Math.Max);
            var possible = max["red"] <= 12 && max["green"] <= 13 && max["blue"] <= 14;
            if (possible)
            {
                part1 += gameNumber;
            }
            part2 += max["red"] * max["green"] * max["blue"];

        }
        return (part1.ToString(), part2.ToString());
    }
}
