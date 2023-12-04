
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day4 : ISolver
{
    public (string, string) ExpectedResult => ("20855", "");

    public (string, string) Solve(string[] input)
    {
        var part1 = input.Select(card => card.Split(':', '|').Select(n => Regex.Matches(n, @"\d+").Select(m => int.Parse(m.Value)).ToArray()).ToArray())
            .Select(c => new { Card = c[0][0], WinningNumbers = c[1], MyNumbers = c[2] })
            .Select(c => c.WinningNumbers.Count(wn => c.MyNumbers.Contains(wn)))
            .Sum(x => x == 0 ? 0 : (1 << (x - 1)));
        return (part1.ToString(), "");
    }
}
